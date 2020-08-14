
<template>
  <a-modal
    title="文件"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
        <a-card :bordered="false">
        
        <detail-list>
          <detail-list-item term="原名称">{{entity.oldName}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="新名称">{{entity.newName}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="扩展名">{{entity.extension}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="大小">{{entity.size}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="Md5">{{entity.md5}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="路径">{{entity.src}}</detail-list-item>
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
          .get('/api/Sysfile/' + id)
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

