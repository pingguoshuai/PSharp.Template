<template>
  <a-modal
    title="管理员"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    :footer="null"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-card :bordered="false">
        <detail-list :col="1">
          <detail-list-item term="用户名">{{ entity.userName }}</detail-list-item>
          <detail-list-item term="昵称">{{ entity.nickName }}</detail-list-item>
          <detail-list-item term="姓名">{{ entity.name }}</detail-list-item>
          <detail-list-item term="安全邮箱">{{ entity.email }}</detail-list-item>
          <detail-list-item term="安全手机">{{ entity.phoneNumber }}</detail-list-item>
          <detail-list-item term="启用">
            <a-tag v-if="entity.enabled" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
      </a-card>
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
      labelCol: { xs: { span: 24 }, sm: { span: 7 } },
      wrapperCol: { xs: { span: 24 }, sm: { span: 13 } },
      visible: false,
      confirmLoading: false,
      entity: {}
    }
  },
  methods: {
    detail(id) {
      this.visible = true
      this.entity = {}
      this.confirmLoading = true
      axios
        .get('User/' + id)
        .then(res => {
          this.entity = res.data

          this.confirmLoading = false
        })
        .catch(errors => {
          this.confirmLoading = false
        })
    },
    handleCancel() {
      this.visible = false
    }
  }
}
</script>

