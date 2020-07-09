<template>
  <a-modal
    title="分配角色"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    :destroyOnClose="true"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
        <a-form-item label="选择角色" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-select mode="multiple" placeholder="请选择分配的角色" v-decorator="['roleIds', roleIdsCheck]">
            <a-select-option v-for="item in roleList" :key="item.id" :value="item.id">
              {{ item.name }}
            </a-select-option>
          </a-select>
        </a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>

<script>
import { axios } from '@/utils/request'

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
      labelCol: { xs: { span: 24 }, sm: { span: 7 } },
      wrapperCol: { xs: { span: 24 }, sm: { span: 13 } },
      visible: false,
      confirmLoading: false,
      roleList: [],
      entity: {},
      roleIdsCheck: {
        rules: [{ required: true, message: '请选择分配的角色' }]
      }
    }
  },
  methods: {
    distribute(id) {
      this.visible = true
      this.entity = {}
      this.entity.userId = id
      this.getRoleList()
      this.$nextTick(() => {
        this.form.resetFields()
        var formFields = this.form.getFieldsValue()
        this.confirmLoading = true
        axios
          .get('User/GetRolesIds?userId='+id)
          .then(res => {
            this.entity.roleIds = res.data
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
    getRoleList() {
      this.confirmLoading = true
      axios
        .get('Role')
        .then(res => {
          this.roleList = res.data.data
          this.confirmLoading = false
        })
        .catch(() => {
          this.confirmLoading = false
        })
    },
    handleSubmit() {
      this.form.validateFields((errors, values) => {
        console.log(values)
        if (!errors) {
          let entity = {
            userId: this.entity.userId,
            roleIds: values.roleIds.join(',')
          }
          this.confirmLoading = true
          axios
            .post('User/AddRolesToUser', entity)
            .then(res => {
              this.visible = false
              this.confirmLoading = false
              this.$message.success(`添加成功`)
            })
            .catch(errors => {
              this.confirmLoading = false
            })
        }
      })
    },
    handleCancel() {
      this.visible = false
    }
  }
}
</script>

