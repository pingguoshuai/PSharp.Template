
<template>
  <a-modal
    title="资源"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    :footer="null"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-card :bordered="false">
        <detail-list :col="1">
          <detail-list-item term="菜单名称">{{ entity.name }}</detail-list-item>
          <detail-list-item term="路由名称">{{ entity.routeName }}</detail-list-item>
          <detail-list-item term="路由地址">{{ entity.routeUri }}</detail-list-item>
          <!-- <detail-list-item term="ParentId">{{entity.parentId}}</detail-list-item> -->
          <!-- <detail-list-item term="Path">{{entity.path}}</detail-list-item> -->
          <detail-list-item term="资源类型">{{ entity.type }}</detail-list-item>
          <detail-list-item term="等级">{{ entity.level }}</detail-list-item>
          <detail-list-item term="是否启用">
            <a-tag v-if="entity.enabled" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
          <detail-list-item term="SortId">{{ entity.sortId }}</detail-list-item>
          <detail-list-item term="是否隐藏">
            <a-tag v-if="entity.isHide" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
          <detail-list-item term="接口">{{ entity.interfaceCode }}</detail-list-item>
          <detail-list-item term="图标">{{ entity.iconId }}</detail-list-item>
          <detail-list-item term="保持连接">
            <a-tag v-if="entity.keepAlive" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
          <detail-list-item term="是否必选">
            <a-tag v-if="entity.required" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
          <detail-list-item term="备注">{{ entity.remark }}</detail-list-item>
          <detail-list-item term="应用程序">{{ entity.applicationId }}</detail-list-item>
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
  // created(){
  //   this.detail('695c9e82-149b-4fa1-a079-313a0722a63f');
  // },
  methods: {
    detail(id) {
      this.visible = true
      this.entity = {}
      this.confirmLoading = true
      axios
        .get('Resource/' + id)
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

