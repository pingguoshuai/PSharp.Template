
<template>
  <a-modal
    title="栏目"
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
          <detail-list-item term="名称">{{entity.name}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="图片">{{entity.iconId}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="类型">{{entity.typeId}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="自定义名称">{{entity.diyName}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="关键字">{{entity.keywords}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="页面描述">{{entity.descrition}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="链接">{{entity.outLink}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="排序">{{entity.sort}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="分页大小">{{entity.pageSize}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="是否可投稿">
            <a-tag v-if="entity.isContribute" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="导航显示">
            <a-tag v-if="entity.isNav" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="状态">
            <a-tag v-if="entity.status" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="TenantId">{{entity.tenantId}}</detail-list-item>
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
          .get('/api/Column/' + id)
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

