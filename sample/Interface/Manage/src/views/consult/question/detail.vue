
<template>
  <a-modal
    title="咨询"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    :footer="null"
        :destroyOnClose="true"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
        <a-card :bordered="false">
        
        <detail-list col=1>
          <detail-list-item term="标识">{{entity.doctorId}}</detail-list-item>
          <detail-list-item term="会员标识">{{entity.memberId}}</detail-list-item>
          <detail-list-item term="年龄">{{entity.age}}</detail-list-item>
          <detail-list-item term="性别">{{entity.sexId}}</detail-list-item>
          <detail-list-item term="标题">{{entity.title}}</detail-list-item>
          <detail-list-item term="描述">{{entity.content}}</detail-list-item>
          <detail-list-item term="图片">{{entity.imageId}}</detail-list-item>
          <detail-list-item term="是否关闭">
            <a-tag v-if="entity.isClose" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
          <detail-list-item term="评论标识">{{entity.commentId}}</detail-list-item>
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
          .get('Question/' + id)
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

