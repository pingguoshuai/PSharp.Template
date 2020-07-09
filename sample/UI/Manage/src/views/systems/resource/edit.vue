
<template>
  <a-modal
    title="资源"
    :width="700"
    :visible="visible"
    :confirmLoading="confirmLoading"
    :destroyOnClose="true"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-form :form="form" :labelCol="labelCol" :wrapperCol="wrapperCol">
        <a-form-item label="资源类型">
          <a-select v-decorator="['type', { initialValue: 1 }]">
            <a-select-option v-for="item in resourceType" :key="item.value" :value="item.value">
              {{ item.text }}
            </a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="上级菜单">
          <!-- <a-input v-decorator="['parentId', { rules: []}]" /> -->
          <a-tree-select
            v-decorator="['parentId', { rules: [] }]"
            style="width: 100%"
            :dropdown-style="{ maxHeight: '400px', overflow: 'auto' }"
            :tree-data="resourceTreeList"
            tree-data-simple-mode
            placeholder="请选择上级菜单"
            tree-default-expand-all
          >
          </a-tree-select>
        </a-form-item>
        <a-form-item label="菜单名称">
          <a-input
            placeholder="请输入菜单名称"
            v-decorator="[
              'name',
              {
                rules: [
                  { max: 200, message: '不能超过200个字符' },
                  { required: true, message: '请输入菜单名称' }
                ]
              }
            ]"
          />
        </a-form-item>
        <a-form-item label="路由地址">
          <a-input
            placeholder="请输入路由地址"
            v-decorator="[
              'routeUri',
              {
                rules: [
                  { max: 300, message: '不能超过300个字符' },
                  { required: true, message: '请输入路由地址' }
                ]
              }
            ]"
          />
        </a-form-item>
        <a-form-item label="图标">
          <a-input placeholder="请输入图标" v-decorator="['icon', { rules: [] }]" />
        </a-form-item>
        <a-form-item label="路由名称">
          <a-input
            placeholder="请输入路由名称"
            v-decorator="['routeName', { rules: [{ max: 200, message: '不能超过200个字符' }] }]"
          />
        </a-form-item>
        <a-form-item label="排序">
          <a-input-number
            placeholder="请输入排序"
            v-decorator="['sortId', { rules: [{ type: 'number', message: '请输入正确的SortId' }], initialValue: 1 }]"
          />
        </a-form-item>
        <a-form-item label="启用">
          <a-switch v-decorator="['enabled', { valuePropName: 'checked', initialValue: true }]" />
        </a-form-item>
        <a-form-item label="KeepAlive">
          <a-switch v-decorator="['keepAlive', { valuePropName: 'checked', initialValue: false }]" />
        </a-form-item>
        <a-form-item label="是否隐藏">
          <a-switch v-decorator="['isHide', { valuePropName: 'checked', initialValue: false }]" />
        </a-form-item>
        <!-- <a-form-item label="API接口" :labelCol="labelCol1" :wrapperCol="wrapperCol1">
          <a-select
            show-search
            option-filter-prop="children"
            :filter-option="filterOption"
            v-decorator="['interfaceId', { initialValue: '' }]"
          >
            <a-select-option value=""><span style="float: left">无需api</span></a-select-option>
            <a-select-option v-for="item in interfaceList" :key="item.id" :value="item.id">
              <span style="float: left">{{ item.contorller }}_{{ item.action }}</span>
              <span style="float: right; color: #8492a6; font-size: 13px">{{ item.name }}</span>
            </a-select-option>
          </a-select>
        </a-form-item> -->
        <!-- <a-form-item label="应用程序">
              <a-input v-decorator="['applicationId', { rules: []}]" />
            </a-form-item> -->
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
  data() {
    return {
      form: this.$form.createForm(this),
      labelCol: { xs: { span: 24 }, sm: { span: 8 } },
      wrapperCol: { xs: { span: 24 }, sm: { span: 14 } },
      labelCol1: { xs: { span: 24 }, sm: { span: 4 } },
      wrapperCol1: { xs: { span: 24 }, sm: { span: 19 } },
      visible: false,
      confirmLoading: false,
      entity: {},
      isadd: true,
      // interfaceList: [],
      resourceType: [],
      resourceTreeList: []
    }
  },
  methods: {
    init() {
      // axios.get('Interface/Query').then(res => {
      //   this.interfaceList = res.data
      // })
      axios.get('Resource/getresourcetype').then(res => {
        this.resourceType = res.data
      })
      axios.get('Resource?applicationId=' + this.entity.applicationId).then(res => {
        this.resourceTreeList = res.data
      })
    },
    add(applicationId) {
      this.entity.applicationId = applicationId
      this.init()
      this.visible = true
      this.isadd = true
      this.form.resetFields()
    },
    edit(id, applicationId) {
      this.entity.applicationId = applicationId
      this.visible = true
      this.isadd = false
      this.init()
      this.$nextTick(() => {
        this.form.resetFields()
        var formFields = this.form.getFieldsValue()

        this.confirmLoading = true
        axios
          .get('Resource/' + id)
          .then(res => {
            this.entity = res.data
            // if (this.entity.interfaceId == null) {
            //   this.entity.interfaceId = ''
            // }
            var setData = {}
            Object.keys(formFields).forEach(item => {
              setData[item] = this.entity[item]
            })

            this.form.setFieldsValue(setData)
            this.confirmLoading = false
          })
          .catch(errors => {
            this.confirmLoading = false
          })
      })
    },
    handleSubmit() {
      this.form.validateFields((errors, values) => {
        if (!errors) {
          this.entity = Object.assign(this.entity, this.form.getFieldsValue())
          this.confirmLoading = true
          if (this.isadd) {
            axios
              .post('Resource', this.entity)
              .then(res => {
                this.visible = false
                this.confirmLoading = false
                this.afterSubmit()
              })
              .catch(errors => {
                this.confirmLoading = false
              })
          } else {
            axios
              .put('Resource', this.entity)
              .then(res => {
                this.visible = false
                this.confirmLoading = false
                this.afterSubmit()
              })
              .catch(errors => {
                this.confirmLoading = false
              })
          }
        }
      })
    },
    handleCancel() {
      this.visible = false
      this.entity = {}
    },
    filterOption(input, option) {
      return option.componentOptions.children[0].children[0].text.toLowerCase().indexOf(input.toLowerCase()) >= 0
    }
  }
}
</script>

<style scoped>
@media (min-width: 640px) {
  .ant-form {
    display: flex;
    flex-wrap: wrap;
  }
  .ant-form > div {
    width: 50%;
  }
  .ant-form > div:last-child {
    width: 100%;
  }
}
</style>