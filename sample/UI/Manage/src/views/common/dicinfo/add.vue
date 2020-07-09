<template>
    <a-modal
        title="新建参数"
        :width="640"
        :visible="visible"
        :confirmLoading="confirmLoading"
        @ok="handleSubmit"
        @cancel="handleCancel"
    >
        <a-spin :spinning="confirmLoading">
            <a-form :form="form">
                <a-form-item label="名称" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-input name="name" placeholder="请输入名称" v-decorator="['name', nameCheck]" />
                </a-form-item>
                <a-form-item label="字典值" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-input name="value" placeholder="请输入字典值" v-decorator="['value', valueCheck]" />
                </a-form-item>
                <a-form-item label="字典类型" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-select placeholder="请选择字典类型" v-decorator="['dicTypeId', dictypeCheck]">
                        <a-select-option v-for="(item, index) in dicTypeList" :value="item.id" :key="'info' + index">
                            {{ item.name }}
                        </a-select-option>
                    </a-select>
                </a-form-item>
                <a-form-item label="字典排序" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-input type="number" placeholder="请输入字典排序" v-decorator="['sort', sortCheck]" />
                </a-form-item>
                <a-form-item label="是否启用" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-switch v-decorator="['status', statusCheck]" v-model="status" />
                </a-form-item>
            </a-form>
        </a-spin>
    </a-modal>
</template>

<script>
import { axios } from '@/utils/request'
export default {
    data() {
        return {
            labelCol: {
                xs: { span: 24 },
                sm: { span: 7 }
            },
            wrapperCol: {
                xs: { span: 24 },
                sm: { span: 13 }
            },
            visible: false,
            confirmLoading: false,
            form: this.$form.createForm(this),
            status: true,
            dicTypeList: [],
            nameCheck: {
                initialValue: '',
                rules: [
                    { required: true, message: '请输入名称' },
                    { max: 50, message: '不能超过50个字符' }
                ]
            },
            valueCheck: {
                initialValue: '',
                rules: [
                    { required: true, message: '请输入字典值' },
                    { max: 50, message: '不能超过50个字符' }
                ]
            },
            dictypeCheck: { rules: [{ required: true, message: '请选择字典类型' }] },
            sortCheck: {
                initialValue: '',
                rules: [{ max: 50, message: '不能超过50个字符' }]
            },
            statusCheck: { initialValue: true }
        }
    },

    methods: {
        getDataList() {
            axios.get('Dictype/').then(res => {
                this.dicTypeList = res.data.data
            })
        },

        add() {
            this.visible = true
            this.form.resetFields()
            this.getDataList()
        },
        handleSubmit() {
            this.confirmLoading = true
            this.form.validateFields((errors, values) => {
                if (!errors) {
                    let data = {
                        name: values.name,
                        value: values.value,
                        sort: values.sort,
                        dicTypeId: values.dicTypeId,
                        status: values.status
                    }
                    axios.post('DicInfo', data).then(res => {
                        setTimeout(() => {
                            this.visible = false
                            this.confirmLoading = false
                            this.$emit('ok', values)
                            this.getDataList()
                        }, 1500)
                    })
                } else {
                    this.confirmLoading = false
                }
            })
        },
        handleCancel() {
            this.visible = false
        }
    }
}
</script>
