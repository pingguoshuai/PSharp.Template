<template>
  <a-modal
    title="管理员"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    :destroyOnClose="true"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
        <a-form-item label="用户名" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input placeholder="请输入用户名" v-decorator="['userName', userNameCheck]" />
        </a-form-item>
        <a-form-item label="昵称" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input placeholder="请输入昵称" v-decorator="['nickName', nickNameCheck]" />
        </a-form-item>
        <a-form-item label="姓名" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input placeholder="请输入姓名" v-decorator="['name', nameCheck]" />
        </a-form-item>
        <a-form-item label="邮箱" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input placeholder="请输入邮箱" v-decorator="['email', emailCheck]" />
        </a-form-item>
        <a-form-item label="手机" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input placeholder="请输入手机" v-decorator="['phoneNumber', phoneNumberCheck]" />
        </a-form-item>
        <a-form-item label="密码" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input-password :placeholder="passwordData.placeholder" v-decorator="['password', passwordData.Check]" />
        </a-form-item>
        <a-form-item label="启用" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch v-decorator="['enabled', enabledCheck]" />
        </a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>

<script>
import { axios } from '@/utils/request'

export default {
  props: {
    afterSubmit: {
      type: Function,
      default: null
    }
  },
  data() {
    return {
      form: this.$form.createForm(this),
      labelCol: { xs: { span: 24 }, sm: { span: 7 } },
      wrapperCol: { xs: { span: 24 }, sm: { span: 13 } },
      visible: false,
      confirmLoading: false,
      entity: {},
      isadd: true,
      userNameCheck: {
        rules: [
          { max: 256, message: '不能超过256个字符' },
          { required: true, message: '请输入用户名' }
        ]
      },
      nickNameCheck: {
        rules: [
          { max: 256, message: '不能超过256个字符' },
          { required: true, message: '请输入昵称' }
        ]
      },
      nameCheck: {
        rules: [
          { max: 256, message: '不能超过256个字符' },
          { required: true, message: '请输入姓名' }
        ]
      },
      emailCheck: {
        rules: [
          { pattern: /^([a-zA-Z\d])(\w|\-)+@[a-zA-Z\d]+\.[a-zA-Z]{2,4}$/, message: '请输入正确的邮箱' },
          { max: 256, message: '不能超过256个字符' },
          { required: true, message: '请输入邮箱' }
        ]
      },
      phoneNumberCheck: {
        rules: [
          { pattern: /^[1][3,4,5,7,8][0-9]{9}$/, message: '请输入正确的手机号' },
          { required: true, message: '请输入手机' }
        ]
      },
      passwordData: {},
      passwordAdd: {
        placeholder: '请输入密码',
        Check: {
          rules: [
            { max: 16, message: '不能超过16个字符' },
            { required: true, message: '请输入密码' }
          ]
        }
      },
      passwordEdit: {
        placeholder: '若不需修改密码请跳过该行',
        Check: { rules: [{ max: 16, message: '不能超过16个字符' }] }
      },
      enabledCheck: { valuePropName: 'checked', initialValue: true }
    }
  },
  methods: {
    add() {
      this.visible = true
      this.isadd = true
      this.form.resetFields()
      this.entity = {}
      this.passwordData = this.passwordAdd
    },
    edit(id) {
      this.visible = true
      this.isadd = false
      this.entity = {}
      this.passwordData = this.passwordEdit
      this.$nextTick(() => {
        this.form.resetFields()
        var formFields = this.form.getFieldsValue()
        this.confirmLoading = true
        axios
          .get('User/' + id)
          .then(res => {
            this.entity = res.data
            var setData = {}
            Object.keys(formFields).forEach(item => {
              setData[item] = this.entity[item]
            })
            this.form.setFieldsValue(setData)
            this.confirmLoading = false
          })
          .catch(errors => {
            this.confirmLoading = false
          })
      })
    },
    handleSubmit() {
      this.form.validateFields((errors, values) => {
        if (!errors) {
          let entity = Object.assign(this.entity, this.form.getFieldsValue())
          this.confirmLoading = true
          if (this.isadd) {
            axios
              .post('User', entity)
              .then(res => {
                this.visible = false
                this.confirmLoading = false
                this.afterSubmit()
              })
              .catch(errors => {
                this.confirmLoading = false
              })
          } else {
            axios
              .put('User', entity)
              .then(res => {
                this.visible = false
                this.confirmLoading = false
                this.afterSubmit()
              })
              .catch(errors => {
                this.confirmLoading = false
              })
          }
        }
      })
    },
    handleCancel() {
      this.visible = false
    }
  }
}
</script>

