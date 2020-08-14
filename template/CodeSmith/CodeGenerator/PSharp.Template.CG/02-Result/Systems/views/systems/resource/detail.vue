
<template>
  <a-modal
    title="身份资源"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
        <a-card :bordered="false">
        
        <detail-list>
          <detail-list-item term="ParentId">{{entity.parentId}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="Path">{{entity.path}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="Level">{{entity.level}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="Enabled">
            <a-tag v-if="entity.enabled" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="SortId">{{entity.sortId}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="Name">{{entity.name}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="RouteName">{{entity.routeName}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="RouteUri">{{entity.routeUri}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="资源类型">{{entity.type}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="IsHide">
            <a-tag v-if="entity.isHide" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="图标">{{entity.icon}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="KeepAlive">
            <a-tag v-if="entity.keepAlive" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="Remark">{{entity.remark}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="Required">
            <a-tag v-if="entity.required" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="ApplicationId">{{entity.applicationId}}</detail-list-item>
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
          .get('/api/Resource/' + id)
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

