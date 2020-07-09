
<template>
  <a-modal
    title="应用程序"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
            <a-form-item label="应用程序名称" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['name',  { rules: [{max: 60, message: '不能超过60个字符'},{required: true, message: '请输入应用程序名称'},]}]" />
            </a-form-item>
            <a-form-item label="应用程序编码" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['code', { rules: [{max: 60, message: '不能超过80个字符'},{required: true, message: '请输入应用程序编码'},]}]" />
            </a-form-item>
        <a-form-item label="启用" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['enabled', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
            <a-form-item label="扩展" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['extend',  { rules: [{max: 21845, message: '不能超过21845个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="备注" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['remark',  { rules: [{max: 666, message: '不能超过666个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
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
        axios.get('Application/'+id).then(res => {
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
            axios.post('Application', this.entity).then(res => {
                this.visible = false
                this.confirmLoading = false
                this.afterSubmit();
            }).catch(errors=>{
              this.confirmLoading = false
            })
          }else{
            axios.put('Application', this.entity).then(res => {
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

