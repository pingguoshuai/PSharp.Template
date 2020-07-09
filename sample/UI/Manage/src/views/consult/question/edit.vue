
<template>
  <a-modal
    title="咨询"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
            <a-form-item label="标识" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['doctorId', { rules: [{required: true, message: '请输入标识'},]}]" />
            </a-form-item>
            <a-form-item label="会员标识" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['memberId', { rules: [{required: true, message: '请输入会员标识'},]}]" />
            </a-form-item>
        <a-form-item label="年龄" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['age', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
            <a-form-item label="性别" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['sexId', { rules: []}]" />
            </a-form-item>
            <a-form-item label="标题" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['title', { rules: [{max: 200, message: '不能超过200个字符'},{required: true, message: '请输入标题'},]}]" />
            </a-form-item>
            <a-form-item label="描述" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['content', { rules: [{max: 255, message: '不能超过255个字符'},{required: true, message: '请输入描述'},]}]" />
            </a-form-item>
            <a-form-item label="图片" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['imageId', { rules: []}]" />
            </a-form-item>
        <a-form-item label="是否关闭" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['isClose', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
            <a-form-item label="评论标识" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['commentId', { rules: []}]" />
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
        axios.get('Question/'+id).then(res => {
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
            axios.post('Question', this.entity).then(res => {
                this.visible = false
                this.confirmLoading = false
                this.afterSubmit();
            }).catch(errors=>{
              this.confirmLoading = false
            })
          }else{
            axios.put('Question', this.entity).then(res => {
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

