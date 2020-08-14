
<template>
  <a-modal
    title="管理员"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
        <a-card :bordered="false">
        
        <detail-list>
          <detail-list-item term="用户名">{{entity.userName}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="标准化用户名">{{entity.normalizedUserName}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="昵称">{{entity.nickName}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="姓名">{{entity.name}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="安全邮箱">{{entity.email}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="标准化邮箱">{{entity.normalizedEmail}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="邮箱已确认">
            <a-tag v-if="entity.emailConfirmed" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="安全手机">{{entity.phoneNumber}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="手机已确认">
            <a-tag v-if="entity.phoneNumberConfirmed" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="密码">{{entity.password}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="密码散列">{{entity.passwordHash}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="安全码">{{entity.safePassword}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="安全码散列">{{entity.safePasswordHash}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="启用锁定">
            <a-tag v-if="entity.lockoutEnabled" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="锁定截止">{{entity.lockoutEnd}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="上次登陆时间">{{entity.lastLoginTime}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="上次登陆Ip">{{entity.lastLoginIp}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="本次登陆时间">{{entity.currentLoginTime}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="本次登陆Ip">{{entity.currentLoginIp}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="登陆次数">{{entity.loginCount}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="登陆失败次数">{{entity.accessFailedCount}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="启用两阶段认证">
            <a-tag v-if="entity.twoFactorEnabled" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="启用">
            <a-tag v-if="entity.enabled" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="冻结时间">{{entity.disabledTime}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="注册Ip">{{entity.registerIp}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="安全戳">{{entity.securityStamp}}</detail-list-item>
        </detail-list>
        <detail-list>
          <detail-list-item term="备注">{{entity.remark}}</detail-list-item>
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
          .get('/api/User/' + id)
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

