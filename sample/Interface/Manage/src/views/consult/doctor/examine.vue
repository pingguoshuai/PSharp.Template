
<template>
  <a-modal
    title="医生"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-card :bordered="false">
        <detail-list :col="2">
          <detail-list-item term="申请医院">{{ entity.yiYuanName }}</detail-list-item>
          <detail-list-item term="申请科室">{{ entity.keShiName }}</detail-list-item>
          <detail-list-item term="医生姓名">{{ entity.name }}</detail-list-item>
          <detail-list-item term="医生手机">{{ entity.phoneNumber }}</detail-list-item>
          <detail-list-item term="医生职称">{{ entity.title }}</detail-list-item>
          <detail-list-item term="资质证明">{{ entity.files }}</detail-list-item>
        </detail-list>
      </a-card>
      <a-form :form="form" :labelCol="labelCol" :wrapperCol="wrapperCol">
        <a-form-item label="选择医院">
          <a-select placeholder="请选择医院" v-decorator="['hospitalId', hospitalIdCheck]">
            <a-select-option v-for="(item, index) in hospitalList" :value="item.id" :key="index">
              {{ item.name }}
            </a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="选择科室">
          <a-select placeholder="请选择科室" v-decorator="['departmentId', departmentIdCheck]">
            <a-select-option v-for="(item, index) in departmentList" :value="item.id" :key="index">
              {{ item.name }}
            </a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="审核">
          <a-select placeholder="请选择审核状态" v-decorator="['auditId', auditIdCheck]">
            <a-select-option v-for="(item, index) in auditList" :value="item.id" :key="index">
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
import DetailList from '@/components/tools/DetailList'
const DetailListItem = DetailList.Item

export default {
  components: {
    DetailList,
    DetailListItem
  },
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
      entity: {},
      hospitalList: [],
      departmentList: [],
      auditList: [],
      hospitalIdCheck: { rules: [{ required: true, message: '请选择医院' }] },
      departmentIdCheck: { rules: [{ required: true, message: '请选择科室' }] },
      auditIdCheck: { rules: [{ required: true, message: '请选择审核状态' }] }
    }
  },

  created() {
    // this.examine()
  },

  methods: {
    examine(msg) {
      //   msg = {
      //     id: '1c3af3fc-82aa-4f2a-80cd-7727e20c87d8',
      //     auditList: [],
      //     hospitalList: [],
      //     departmentList: []
      //   }
      this.visible = true
      this.entity = {}
      this.confirmLoading = true
      this.auditList = msg.auditList
      this.hospitalList = msg.hospitalList
      this.departmentList = msg.departmentList
      axios
        .get('Doctor/' + msg.id)
        .then(res => {
          this.entity = res.data
          this.confirmLoading = false
        })
        .catch(errors => {
          this.confirmLoading = false
        })
    },
    // 点击确定
    handleSubmit() {
      this.confirmLoading = true
      this.form.validateFields((errors, values) => {
        if (!errors) {
          var postData = this.form.getFieldsValue()
          postData.id = this.entity.id
          postData.version = this.entity.version
          axios
            .post('Doctor/Audit', postData)
            .then(res => {
              console.log(res)
              this.visible = false
              this.confirmLoading = false
              this.afterSubmit()
            })
            .catch(err => {
              this.confirmLoading = false
            })
        } else {
          this.confirmLoading = false
        }
      })
    },
    handleCancel() {
      this.visible = false
    }
  }
}
</script>
