
<template>
  <a-modal
    title="权限"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
        <a-card :bordered="false">
        
        <detail-list>
          <detail-list-item term="角色标识">{{entity.roleId}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="资源标识">{{entity.resourceId}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="拒绝">
            <a-tag v-if="entity.isDeny" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="签名">{{entity.sign}}</detail-list-item>
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
          .get('Permission/' + id)
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

