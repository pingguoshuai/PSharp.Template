
<template>
  <a-modal
    title="栏目"
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
            <a-form-item label="名称" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['name', { rules: [{max: 200, message: '不能超过200个字符'},{required: true, message: '请输入名称'},]}]" />
            </a-form-item>
            <a-form-item label="图片" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['iconId', { rules: []}]" />
            </a-form-item>
            <a-form-item label="类型" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['typeId', { rules: [{required: true, message: '请输入类型'},]}]" />
            </a-form-item>
            <a-form-item label="自定义名称" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['diyName', { rules: [{max: 200, message: '不能超过200个字符'},{required: true, message: '请输入自定义名称'},]}]" />
            </a-form-item>
            <a-form-item label="关键字" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['keywords',  { rules: [{max: 2000, message: '不能超过2000个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="页面描述" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['descrition',  { rules: [{max: 8000, message: '不能超过8000个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="链接" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['outLink',  { rules: [{max: 1020, message: '不能超过1020个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="排序" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input-number v-decorator="['sort', { rules: [{type: 'number', message: '请输入正确的排序'},{required: true, message: '请输入排序'},], initialValue: 1 }]" />
            </a-form-item>
            <a-form-item label="分页大小" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input-number v-decorator="['pageSize', { rules: [{type: 'number', message: '请输入正确的分页大小'},{required: true, message: '请输入分页大小'},], initialValue: 1 }]" />
            </a-form-item>
        <a-form-item label="是否可投稿" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['isContribute', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
        <a-form-item label="导航显示" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['isNav', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
        <a-form-item label="状态" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['status', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
            <a-form-item label="TenantId" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['tenantId',  { rules: [{max: 2147483647, message: '不能超过2147483647个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
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
        axios.get('/api/Column/'+id).then(res => {
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
            axios.post('/api/Column', this.entity).then(res => {
                this.visible = false
                this.confirmLoading = false
                this.afterSubmit();
            }).catch(errors=>{
              this.confirmLoading = false
            })
          }else{
            axios.put('/api/Column', this.entity).then(res => {
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

