
<template>
  <a-modal
    title="数据字典"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
        <a-card :bordered="false">
        
        <detail-list>
          <detail-list-item term="DicTypeId">{{entity.dicTypeId}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="字典名称">{{entity.name}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="字典值">{{entity.value}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="排序">{{entity.sort}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="字典类型状态">
            <a-tag v-if="entity.status" color="blue">是</a-tag>
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
          .get('/api/Dicinfo/' + id)
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

