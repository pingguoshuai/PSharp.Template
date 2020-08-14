
<template>
  <a-modal
    title="文件"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
            <a-form-item label="原名称" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['oldName',  { rules: [{max: 1200, message: '不能超过1200个字符'},{required: true, message: '请输入原名称'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="新名称" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['newName',  { rules: [{max: 1200, message: '不能超过1200个字符'},{required: true, message: '请输入新名称'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="扩展名" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['extension', { rules: [{max: 40, message: '不能超过40个字符'},{required: true, message: '请输入扩展名'},]}]" />
            </a-form-item>
            <a-form-item label="大小" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input-number v-decorator="['size', { rules: [{type: 'number', message: '请输入正确的大小'},{required: true, message: '请输入大小'},], initialValue: 1 }]" />
            </a-form-item>
            <a-form-item label="Md5" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['md5',  { rules: [{max: 256, message: '不能超过256个字符'},{required: true, message: '请输入Md5'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="路径" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['src',  { rules: [{max: 1020, message: '不能超过1020个字符'},{required: true, message: '请输入路径'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
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
        axios.get('/api/Sysfile/'+id).then(res => {
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
            axios.post('/api/Sysfile', this.entity).then(res => {
                this.visible = false
                this.confirmLoading = false
                this.afterSubmit();
            }).catch(errors=>{
              this.confirmLoading = false
            })
          }else{
            axios.put('/api/Sysfile', this.entity).then(res => {
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

