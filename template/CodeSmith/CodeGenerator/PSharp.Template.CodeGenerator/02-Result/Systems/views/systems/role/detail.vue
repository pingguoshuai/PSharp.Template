
<template>
  <a-modal
    title="角色"
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
          <detail-list-item term="Code">{{entity.code}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="角色名称">{{entity.name}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="NormalizedName">{{entity.normalizedName}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="Type">{{entity.type}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="IsAdmin">
            <a-tag v-if="entity.isAdmin" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="Remark">{{entity.remark}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="PinYin">{{entity.pinYin}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="Sign">{{entity.sign}}</detail-list-item>
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
          .get('/api/Role/' + id)
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

