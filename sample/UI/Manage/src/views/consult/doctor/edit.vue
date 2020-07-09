
<template>
  <a-modal
    title="医生"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-form :form="form" :labelCol="labelCol" :wrapperCol="wrapperCol">
        <a-form-item label="姓名">
          <a-input placeholder="请输入姓名" v-decorator="['name', nameCheck]" />
        </a-form-item>
        <a-form-item label="手机号">
          <a-input-number placeholder="请输入手机号" v-decorator="['phoneNumber', phoneNumberCheck]" />
        </a-form-item>
        <a-form-item label="帐号">
          <a-input placeholder="请输入帐号" v-decorator="['account', accountCheck]" />
        </a-form-item>
        <a-form-item label="密码">
          <a-input-password placeholder="若无需修改，请跳过此行" v-decorator="['password', passwordCheck]" />
        </a-form-item>
        <a-form-item label="医院名称">
          <a-select placeholder="请选择医院" v-decorator="['hospitalId', hospitalIdCheck]">
            <a-select-option v-for="(item, index) in hospitalList" :value="item.id" :key="index">
              {{ item.name }}
            </a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="科室名称">
          <a-select placeholder="请选择科室" v-decorator="['departmentId', departmentIdCheck]">
            <a-select-option v-for="(item, index) in departmentList" :value="item.id" :key="index">
              {{ item.name }}
            </a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="职称">
          <a-input placeholder="请输入职称" v-decorator="['title', titleCheck]" />
        </a-form-item>
        <a-form-item label="关注量">
          <a-input-number placeholder="请输入关注量" v-decorator="['followNum', followNumCheck]" />
        </a-form-item>
        <a-form-item label="咨询量">
          <a-input-number placeholder="请输入咨询量" v-decorator="['consultNum', consultNumCheck]" />
        </a-form-item>
        <a-form-item label="评分">
          <a-input-number placeholder="请输入评分" v-decorator="['score', scoreCheck]" />
        </a-form-item>
        <a-form-item label="介绍">
          <a-textarea
            placeholder="请输入介绍"
            v-decorator="['introduce', introduceCheck]"
            :autoSize="{ minRows: 3, maxRows: 5 }"
          />
        </a-form-item>
        <a-form-item label="擅长">
          <a-textarea
            placeholder="请输入擅长"
            v-decorator="['advantage', advantageCheck]"
            :autoSize="{ minRows: 3, maxRows: 5 }"
          />
        </a-form-item>
        <a-form-item label="审核状态">
          <a-select placeholder="请选择审核状态" v-decorator="['auditId', auditIdCheck]">
            <a-select-option v-for="(item, index) in auditList" :value="item.id" :key="index">
              {{ item.name }}
            </a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="启用">
          <a-switch v-decorator="['enabled', enabledCheck]" />
        </a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>

<script>
import { axios } from '@/utils/request'
import pick from 'lodash.pick'

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
      labelCol: { xs: { span: 24 }, sm: { span: 6 } },
      wrapperCol: { xs: { span: 24 }, sm: { span: 17 } },
      visible: false,
      confirmLoading: false,
      entity: {},
      isadd: true,
      hospitalList: [],
      departmentList: [],
      auditList: [],
      nameCheck: {
        rules: [
          { max: 50, message: '不能超过50个字符' },
          { required: true, message: '请输入姓名' }
        ]
      },
      accountCheck: { rules: [{ max: 256, message: '不能超过256个字符' }] },
      passwordCheck: { rules: [{ max: 1024, message: '不能超过1024个字符' }] },
      phoneNumberCheck: { rules: [{ max: 64, message: '不能超过64个字符' }] },
      titleCheck: {
        rules: [
          { max: 50, message: '不能超过50个字符' },
          { required: true, message: '请输入职称' }
        ]
      },
      introduceCheck: { rules: [{ max: 500, message: '不能超过500个字符' }] },
      advantageCheck: { rules: [{ max: 500, message: '不能超过500个字符' }] },
      followNumCheck: { rules: [{ type: 'number', message: '请输入正确的关注量' }] },
      consultNumCheck: { rules: [{ type: 'number', message: '请输入正确的咨询量' }] },
      scoreCheck: { rules: [] },
      enabledCheck: { valuePropName: 'checked', initialValue: true },
      hospitalIdCheck: { rules: [{ required: true, message: '请选择医院' }] },
      departmentIdCheck: { rules: [{ required: true, message: '请选择科室' }] },
      auditIdCheck: { rules: [{ required: true, message: '请选择审核状态' }] }
    }
  },
  created() {
    // this.edit()
  },
  methods: {
    add() {
      this.visible = true
      this.isadd = true
      this.form.resetFields()
      this.entity = {}
    },
    edit(msg) {
      this.visible = true
      this.isadd = false
      this.entity = {}
      this.auditList = msg.auditList
      this.hospitalList = msg.hospitalList
      this.departmentList = msg.departmentList
      this.$nextTick(() => {
        this.form.resetFields()
        var formFields = this.form.getFieldsValue()
        this.confirmLoading = true
        axios
          .get('Doctor/' + msg.id)
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
              .post('Doctor', entity)
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
              .put('Doctor', entity)
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

<style scoped>
@media (min-width: 640px) {
  .ant-form {
    display: flex;
    flex-wrap: wrap;
  }
  .ant-form > div {
    width: 50%;
  }
}
</style>