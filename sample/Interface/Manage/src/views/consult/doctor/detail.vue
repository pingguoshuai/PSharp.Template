
<template>
    <a-modal
        title="医生"
        :width="640"
        :visible="visible"
        :confirmLoading="confirmLoading"
        :footer="null"
        :destroyOnClose="true"
        @cancel="handleCancel"
    >
        <a-spin :spinning="confirmLoading">
            <a-card :bordered="false">
                <detail-list :col="1">
                    <detail-list-item term="医生头像">
                        <a-avatar :src="entity.doctorMemberHeadImgSrc" shape="square" />
                    </detail-list-item>
                    <detail-list-item term="医生姓名">{{ entity.name }}</detail-list-item>
                    <detail-list-item term="医生手机">{{ entity.phoneNumber }}</detail-list-item>
                    <detail-list-item term="医生职称">{{ entity.title }}</detail-list-item>
                    <detail-list-item term="医院名称">{{ entity.hospitalName }}</detail-list-item>
                    <detail-list-item term="科室名称">{{ entity.departmentName }}</detail-list-item>
                    <detail-list-item term="医生帐号">{{ entity.account }}</detail-list-item>
                    <detail-list-item term="医生密码">{{ entity.password }}</detail-list-item>
                    <detail-list-item term="医生简介">{{ entity.introduce }}</detail-list-item>
                    <detail-list-item term="医生擅长">{{ entity.advantage }}</detail-list-item>
                    <detail-list-item term="关注量">{{ entity.followNum }}</detail-list-item>
                    <detail-list-item term="咨询量">{{ entity.consultNum }}</detail-list-item>
                    <detail-list-item term="评分">{{ entity.score }}</detail-list-item>
                    <detail-list-item term="审核状态">{{ entity.auditName }}</detail-list-item>
                    <detail-list-item term="启用">
                        <a-tag v-if="entity.enabled" color="blue">是</a-tag>
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
        detail(msg) {
            this.visible = true
            this.entity = msg
            // this.entity = {}
            // this.confirmLoading = true
            // axios
            //     .get('Doctor/' + msg.id)
            //     .then(res => {
            //         this.entity = res.data
            //         this.confirmLoading = false
            //     })
            //     .catch(errors => {
            //         this.confirmLoading = false
            //     })
        },
        handleCancel() {
            this.visible = false
        }
    }
}
</script>

