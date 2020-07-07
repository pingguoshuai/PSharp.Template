
<template>
  <a-modal
    title="接口"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
            <a-form-item label="名称" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['name', { rules: [{max: 83, message: '不能超过83个字符'},{required: true, message: '请输入名称'},]}]" />
            </a-form-item>
            <a-form-item label="模块编码" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['moduleCode', { rules: [{max: 16, message: '不能超过16个字符'},]}]" />
            </a-form-item>
            <a-form-item label="控制器" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['contorller', { rules: [{max: 16, message: '不能超过16个字符'},{required: true, message: '请输入控制器'},]}]" />
            </a-form-item>
            <a-form-item label="操作" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['action', { rules: [{max: 16, message: '不能超过16个字符'},{required: true, message: '请输入操作'},]}]" />
            </a-form-item>
            <a-form-item label="路由" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['route', { rules: [{max: 16, message: '不能超过16个字符'},{required: true, message: '请输入路由'},]}]" />
            </a-form-item>
            <a-form-item label="请求方式" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input-number v-decorator="['httpMethod', { rules: [{type: 'number', message: '请输入正确的请求方式'},{required: true, message: '请输入请求方式'},], initialValue: 1 }]" />
            </a-form-item>
            <a-form-item label="唯一编码" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['code', { rules: [{max: 66, message: '不能超过66个字符'},{required: true, message: '请输入唯一编码'},]}]" />
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
        axios.get('Interface/'+id).then(res => {
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
            axios.post('Interface', this.entity).then(res => {
                this.visible = false
                this.confirmLoading = false
                this.afterSubmit();
            }).catch(errors=>{
              this.confirmLoading = false
            })
          }else{
            axios.put('Interface', this.entity).then(res => {
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

