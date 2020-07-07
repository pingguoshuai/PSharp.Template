
<template>
  <a-modal
    title="会员"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
            <a-form-item label="昵称" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['nickName', { rules: [{max: 200, message: '不能超过200个字符'},]}]" />
            </a-form-item>
        <a-form-item label="性别" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['sex', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
            <a-form-item label="头像" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['headImgId', { rules: []}]" />
            </a-form-item>
            <a-form-item label="微信用户标识" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['openId', { rules: [{max: 128, message: '不能超过128个字符'},{required: true, message: '请输入微信用户标识'},]}]" />
            </a-form-item>
            <a-form-item label="微信统一标识" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['unionid', { rules: [{max: 128, message: '不能超过128个字符'},]}]" />
            </a-form-item>
            <a-form-item label="姓名" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['fullName', { rules: [{max: 50, message: '不能超过50个字符'},]}]" />
            </a-form-item>
            <a-form-item label="手机号" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['phoneNumber', { rules: [{max: 64, message: '不能超过64个字符'},]}]" />
            </a-form-item>
            <a-form-item label="生日" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['birthday', { rules: []}]" />
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
        axios.get('Member/'+id).then(res => {
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
            axios.post('Member', this.entity).then(res => {
                this.visible = false
                this.confirmLoading = false
                this.afterSubmit();
            }).catch(errors=>{
              this.confirmLoading = false
            })
          }else{
            axios.put('Member', this.entity).then(res => {
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

