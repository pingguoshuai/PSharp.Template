
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
            <a-form-item label="ParentId" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['parentId', { rules: []}]" />
            </a-form-item>
            <a-form-item label="Path" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['path',  { rules: [{max: 2147483647, message: '不能超过2147483647个字符'},{required: true, message: '请输入Path'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="Level" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input-number v-decorator="['level', { rules: [{type: 'number', message: '请输入正确的Level'},{required: true, message: '请输入Level'},], initialValue: 1 }]" />
            </a-form-item>
        <a-form-item label="Enabled" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['enabled', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
            <a-form-item label="SortId" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input-number v-decorator="['sortId', { rules: [{type: 'number', message: '请输入正确的SortId'},], initialValue: 1 }]" />
            </a-form-item>
            <a-form-item label="Code" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['code',  { rules: [{max: 1024, message: '不能超过1024个字符'},{required: true, message: '请输入Code'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="角色名称" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['name',  { rules: [{max: 1024, message: '不能超过1024个字符'},{required: true, message: '请输入角色名称'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="NormalizedName" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['normalizedName',  { rules: [{max: 1024, message: '不能超过1024个字符'},{required: true, message: '请输入NormalizedName'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="Type" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['type',  { rules: [{max: 320, message: '不能超过320个字符'},{required: true, message: '请输入Type'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
        <a-form-item label="IsAdmin" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['isAdmin', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
            <a-form-item label="Remark" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['remark',  { rules: [{max: 2000, message: '不能超过2000个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="PinYin" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['pinYin',  { rules: [{max: 800, message: '不能超过800个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="Sign" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['sign',  { rules: [{max: 1024, message: '不能超过1024个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
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
  data () {
    return {
      form: this.$form.createForm(this),
      labelCol: { xs: { span: 24 }, sm: { span: 7 } },
      wrapperCol: { xs: { span: 24 }, sm: { span: 13 } },
      visible: false,
      confirmLoading: false,
      entity: {},
      isadd : true
    }
  },
  methods: {
    add () {
      this.visible = true;
      this.isadd = true;
      this.form.resetFields();
      this.entity = {};
    },
    edit(id){
      this.visible = true;
      this.isadd = false;
      this.entity = {};
      this.$nextTick(() => {
        this.form.resetFields();
        var formFields = this.form.getFieldsValue()

        this.confirmLoading = true
        axios.get('/api/Role/'+id).then(res => {
          this.entity = res.data;

          var setData = {}
          Object.keys(formFields).forEach(item => {
            setData[item] = this.entity[item]
          })

          this.form.setFieldsValue(setData)
          this.confirmLoading = false
        }).catch(errors=>{
          this.confirmLoading = false
        })
      })
    },
    handleSubmit () {
      this.form.validateFields((errors,values)=>{
        if(!errors){
          this.entity = Object.assign(this.entity, this.form.getFieldsValue());
          this.confirmLoading = true
          if(this.isadd){
            axios.post('/api/Role', this.entity).then(res => {
                this.visible = false
                this.confirmLoading = false
                this.afterSubmit();
            }).catch(errors=>{
              this.confirmLoading = false
            })
          }else{
            axios.put('/api/Role', this.entity).then(res => {
                this.visible = false
                this.confirmLoading = false
                this.afterSubmit();
            }).catch(errors=>{
              this.confirmLoading = false
            })
          }
        }
      });
    },
    handleCancel () {
      this.visible = false
    }
  }
}
</script>

