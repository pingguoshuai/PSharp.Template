
<template>
  <a-modal
    title="文章"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
        <a-card :bordered="false">
        
        <detail-list>
          <detail-list-item term="栏目ID">{{entity.columnId}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="标题">{{entity.title}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="标题样式">{{entity.style}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="关键字">{{entity.keywords}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="页面描述">{{entity.descrition}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="作者">{{entity.author}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="来源">{{entity.source}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="焦点关注">
            <a-tag v-if="entity.isFocus" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="热门推荐">
            <a-tag v-if="entity.isHot" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="图文特推">
            <a-tag v-if="entity.isImg" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="排序">{{entity.sort}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="封面">{{entity.coverId}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="浏览量">{{entity.hits}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="是否外链">
            <a-tag v-if="entity.isLink" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="链接地址">{{entity.linkUrl}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="内容">{{entity.content}}</detail-list-item>
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
          .get('/api/Article/' + id)
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

