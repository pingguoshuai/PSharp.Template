
<template>
  <a-modal
    title="接口"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    :foot="null"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-card :bordered="false">
        <detail-list :col="1">
          <detail-list-item term="名称">{{ entity.name }}</detail-list-item>
          <detail-list-item term="模块编码">{{ entity.moduleCode }}</detail-list-item>
          <detail-list-item term="控制器">{{ entity.contorller }}</detail-list-item>
          <detail-list-item term="操作">{{ entity.action }}</detail-list-item>
          <detail-list-item term="路由">{{ entity.route }}</detail-list-item>
          <detail-list-item term="请求方式">{{ entity.httpMethod }}</detail-list-item>
          <detail-list-item term="唯一编码">{{ entity.code }}</detail-list-item>
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
        .get('Interface/' + id)
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

