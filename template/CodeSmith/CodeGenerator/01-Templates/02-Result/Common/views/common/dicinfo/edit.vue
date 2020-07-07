
<template>
  <a-modal
    title="数据字典"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
            <a-form-item label="DicTypeId" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['dicTypeId', { rules: [{required: true, message: '请输入DicTypeId'},]}]" />
            </a-form-item>
            <a-form-item label="字典名称" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['name', { rules: [{max: 200, message: '不能超过200个字符'},{required: true, message: '请输入字典名称'},]}]" />
            </a-form-item>
            <a-form-item label="字典值" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['value', { rules: [{max: 200, message: '不能超过200个字符'},{required: true, message: '请输入字典值'},]}]" />
            </a-form-item>
            <a-form-item label="排序" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input-number v-decorator="['sort', { rules: [{type: 'number', message: '请输入正确的排序'},{required: true, message: '请输入排序'},], initialValue: 1 }]" />
            </a-form-item>
        <a-form-item label="字典类型状态" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['status', { valuePropName:'checked', initialValue: true }]" />
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
        axios.get('/api/Dicinfo/'+id).then(res => {
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
            axios.post('/api/Dicinfo', this.entity).then(res => {
                this.visible = false
                this.confirmLoading = false
                this.afterSubmit();
            }).catch(errors=>{
              this.confirmLoading = false
            })
          }else{
            axios.put('/api/Dicinfo', this.entity).then(res => {
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

