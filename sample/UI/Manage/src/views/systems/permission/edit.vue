﻿
<template>
  <a-modal
    title="权限"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
            <a-form-item label="角色标识" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['roleId', { rules: [{required: true, message: '请输入角色标识'},]}]" />
            </a-form-item>
            <a-form-item label="资源标识" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['resourceId', { rules: [{required: true, message: '请输入资源标识'},]}]" />
            </a-form-item>
        <a-form-item label="拒绝" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['isDeny', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
            <a-form-item label="签名" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['sign',  { rules: [{max: 341, message: '不能超过341个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
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
        axios.get('Permission/'+id).then(res => {
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
            axios.post('Permission', this.entity).then(res => {
                this.visible = false
                this.confirmLoading = false
                this.afterSubmit();
            }).catch(errors=>{
              this.confirmLoading = false
            })
          }else{
            axios.put('Permission', this.entity).then(res => {
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

