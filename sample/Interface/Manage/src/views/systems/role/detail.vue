
<template>
  <a-modal
    title="角色"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    :footer="null"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-card :bordered="false">
        <detail-list :col="1">
          <detail-list-item term="角色编码">{{ entity.code }}</detail-list-item>
          <detail-list-item term="角色名称">{{ entity.name }}</detail-list-item>
          <detail-list-item term="角色类型">{{ entity.type }}</detail-list-item>
          <detail-list-item term="管理员">
            <a-tag v-if="entity.isAdmin" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
          <detail-list-item term="启用">
            <a-tag v-if="entity.enabled" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
          <detail-list-item term="备注">{{ entity.remark }}</detail-list-item>
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
        .get('Role/' + id)
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

