
<template>
  <a-modal
    title="角色"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
        <a-form-item label="角色编码" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['code', codeCheck]" />
        </a-form-item>
        <a-form-item label="角色名称" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['name', nameCheck]" />
        </a-form-item>
        <a-form-item label="启用" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch v-decorator="['enabled', { valuePropName: 'checked', initialValue: true }]" />
        </a-form-item>
        <a-form-item label="备注" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-textarea
            v-decorator="['remark', { rules: [{ max: 666, message: '不能超过500个字符' }] }]"
            :autoSize="{ minRows: 3, maxRows: 5 }"
          />
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
      labelCol: { xs: { span: 24 }, sm: { span: 7 } },
      wrapperCol: { xs: { span: 24 }, sm: { span: 13 } },
      visible: false,
      confirmLoading: false,
      entity: {},
      isadd: true,
      nameCheck: {
        rules: [
          { max: 256, message: '不能超过256个字符' },
          { required: true, message: '请输入角色名称' }
        ]
      },
      codeCheck: {
        rules: [
          { max: 256, message: '不能超过256个字符' },
          { required: true, message: '请输入角色编码' }
        ]
      }
    }
  },
  methods: {
    add() {
      this.visible = true
      this.isadd = true
      this.form.resetFields()
      this.entity = {}
    },
    edit(id) {
      this.visible = true
      this.isadd = false
      this.entity = {}
      this.$nextTick(() => {
        this.form.resetFields()
        var formFields = this.form.getFieldsValue()

        this.confirmLoading = true
        axios
          .get('Role/' + id)
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
          this.entity = Object.assign(this.entity, this.form.getFieldsValue())
          this.confirmLoading = true
          if (this.isadd) {
            axios
              .post('Role', this.entity)
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
              .put('Role', this.entity)
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

