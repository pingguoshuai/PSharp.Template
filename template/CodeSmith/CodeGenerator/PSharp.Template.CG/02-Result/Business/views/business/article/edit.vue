
<template>
  <a-modal
    title="文章"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
            <a-form-item label="栏目ID" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['columnId', { rules: [{required: true, message: '请输入栏目ID'},]}]" />
            </a-form-item>
            <a-form-item label="标题" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['title',  { rules: [{max: 800, message: '不能超过800个字符'},{required: true, message: '请输入标题'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="标题样式" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['style',  { rules: [{max: 320, message: '不能超过320个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="关键字" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['keywords',  { rules: [{max: 2000, message: '不能超过2000个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="页面描述" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['descrition',  { rules: [{max: 8000, message: '不能超过8000个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="作者" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['author', { rules: [{max: 80, message: '不能超过80个字符'},]}]" />
            </a-form-item>
            <a-form-item label="来源" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['source',  { rules: [{max: 800, message: '不能超过800个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
        <a-form-item label="焦点关注" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['isFocus', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
        <a-form-item label="热门推荐" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['isHot', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
        <a-form-item label="图文特推" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['isImg', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
            <a-form-item label="排序" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input-number v-decorator="['sort', { rules: [{type: 'number', message: '请输入正确的排序'},{required: true, message: '请输入排序'},], initialValue: 1 }]" />
            </a-form-item>
            <a-form-item label="封面" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input v-decorator="['coverId', { rules: []}]" />
            </a-form-item>
            <a-form-item label="浏览量" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input-number v-decorator="['hits', { rules: [{type: 'number', message: '请输入正确的浏览量'},{required: true, message: '请输入浏览量'},], initialValue: 1 }]" />
            </a-form-item>
        <a-form-item label="是否外链" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch  v-decorator="['isLink', { valuePropName:'checked', initialValue: true }]" />
        </a-form-item>
            <a-form-item label="链接地址" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['linkUrl',  { rules: [{max: 800, message: '不能超过800个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
            </a-form-item>
            <a-form-item label="内容" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea v-decorator="['content',  { rules: [{max: 2147483647, message: '不能超过2147483647个字符'},]}]" :autoSize="{ minRows: 3, maxRows: 5 }" />
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
        axios.get('/api/Article/'+id).then(res => {
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
            axios.post('/api/Article', this.entity).then(res => {
                this.visible = false
                this.confirmLoading = false
                this.afterSubmit();
            }).catch(errors=>{
              this.confirmLoading = false
            })
          }else{
            axios.put('/api/Article', this.entity).then(res => {
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

