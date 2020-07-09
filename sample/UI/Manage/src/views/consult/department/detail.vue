
<template>
    <a-modal
        title="科室"
        :width="640"
        :visible="visible"
        :confirmLoading="confirmLoading"
        @cancel="handleCancel"
        :footer="null"
        :destroyOnClose="true"
    >
        <a-spin :spinning="confirmLoading">
            <a-card :bordered="false">
                <detail-list :col="1">
                    <detail-list-item term="名称">{{ entity.name }}</detail-list-item>
                    <detail-list-item term="科室编码">{{ entity.code }}</detail-list-item>
                    <!-- <detail-list-item term="图标">{{entity.iconId}}</detail-list-item> -->
                    <detail-list-item term="图标">
                        <a-avatar :src="entity.iconSrc" shape="square" />
                    </detail-list-item>
                    <detail-list-item term="排序">{{ entity.sortId }}</detail-list-item>
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
import DetailList from '@/components/DescriptionList'
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
            //     .get('Department/' + id)
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

