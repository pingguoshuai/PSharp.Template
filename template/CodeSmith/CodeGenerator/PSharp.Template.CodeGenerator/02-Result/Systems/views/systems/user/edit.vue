
<template>
  <a-modal
    title="管理员"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
            <a-form-item label="用户名" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['userName',  { rules: [{max: 1024, message: '不能超过1024个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="标准化用户名" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['normalizedUserName',  { rules: [{max: 1024, message: '不能超过1024个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="昵称" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['nickName',  { rules: [{max: 1024, message: '不能超过1024个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="姓名" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['name',  { rules: [{max: 1024, message: '不能超过1024个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="安全邮箱" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['email',  { rules: [{max: 1024, message: '不能超过1024个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="标准化邮箱" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['normalizedEmail',  { rules: [{max: 1024, message: '不能超过1024个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
        <a-form-item label="邮箱已确认" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['emailConfirmed', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
            <a-form-item label="安全手机" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['phoneNumber',  { rules: [{max: 256, message: '不能超过256个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
        <a-form-item label="手机已确认" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['phoneNumberConfirmed', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
            <a-form-item label="密码" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['password',  { rules: [{max: 1024, message: '不能超过1024个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="密码散列" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['passwordHash',  { rules: [{max: 4096, message: '不能超过4096个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="安全码" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['safePassword',  { rules: [{max: 1024, message: '不能超过1024个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="安全码散列" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['safePasswordHash',  { rules: [{max: 4096, message: '不能超过4096个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
        <a-form-item label="启用锁定" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['lockoutEnabled', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
            <a-form-item label="锁定截止" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['lockoutEnd', { rules: []}]" />
            </a-form-item>
            <a-form-item label="上次登陆时间" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['lastLoginTime', { rules: []}]" />
            </a-form-item>
            <a-form-item label="上次登陆Ip" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['lastLoginIp', { rules: [{max: 120, message: '不能超过120个字符'},]}]" />
            </a-form-item>
            <a-form-item label="本次登陆时间" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['currentLoginTime', { rules: []}]" />
            </a-form-item>
            <a-form-item label="本次登陆Ip" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['currentLoginIp', { rules: [{max: 120, message: '不能超过120个字符'},]}]" />
            </a-form-item>
            <a-form-item label="登陆次数" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input-number v-decorator="['loginCount', { rules: [{type: 'number', message: '请输入正确的登陆次数'},], initialValue: 1 }]" />
            </a-form-item>
            <a-form-item label="登陆失败次数" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input-number v-decorator="['accessFailedCount', { rules: [{type: 'number', message: '请输入正确的登陆失败次数'},], initialValue: 1 }]" />
            </a-form-item>
        <a-form-item label="启用两阶段认证" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['twoFactorEnabled', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
        <a-form-item label="启用" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['enabled', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
            <a-form-item label="冻结时间" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['disabledTime', { rules: []}]" />
            </a-form-item>
            <a-form-item label="注册Ip" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['registerIp', { rules: [{max: 120, message: '不能超过120个字符'},]}]" />
            </a-form-item>
            <a-form-item label="安全戳" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['securityStamp',  { rules: [{max: 4096, message: '不能超过4096个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="备注" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['remark',  { rules: [{max: 2000, message: '不能超过2000个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
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
        axios.get('/api/User/'+id).then(res => {
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
            axios.post('/api/User', this.entity).then(res => {
                this.visible = false
                this.confirmLoading = false
                this.afterSubmit();
            }).catch(errors=>{
              this.confirmLoading = false
            })
          }else{
            axios.put('/api/User', this.entity).then(res => {
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

