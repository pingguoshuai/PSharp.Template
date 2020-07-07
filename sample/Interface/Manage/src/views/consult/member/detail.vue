
<template>
  <a-modal
    title="会员"
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
          <detail-list-item term="昵称">{{entity.nickName}}</detail-list-item>
          <detail-list-item term="性别">
            <a-tag v-if="entity.sex" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
          <!-- <detail-list-item term="头像">{{entity.headImgId}}</detail-list-item> -->
          <detail-list-item term="头像">
            <a-avatar :src="entity.headImgSrc" shape="square" />
          </detail-list-item>
          <detail-list-item term="微信用户标识">{{entity.openId}}</detail-list-item>
          <detail-list-item term="微信统一标识">{{entity.unionid}}</detail-list-item>
          <detail-list-item term="姓名">{{entity.fullName}}</detail-list-item>
          <detail-list-item term="手机号">{{entity.phoneNumber}}</detail-list-item>
          <detail-list-item term="生日">{{entity.birthday}}</detail-list-item>
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
          .get('Member/' + id)
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

