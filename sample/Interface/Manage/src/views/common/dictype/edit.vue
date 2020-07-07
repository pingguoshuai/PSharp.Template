<template>
    <a-modal
        title="修改类型"
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
                <a-form-item label="字典编码" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-input name="code" placeholder="请输入字典编码" v-decorator="['code', codeCheck]" />
                </a-form-item>
                <a-form-item label="是否启用" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-switch v-decorator="['status', statusCheck]" v-model="editList.status" />
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
            form: this.$form.createForm(this),
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
            editList: {},
            nameCheck: {
                initialValue: '',
                rules: [
                    { required: true, message: '请输入名称' },
                    { max: 50, message: '不能超过50个字符' }
                ]
            },
            codeCheck: {
                initialValue: '',
                rules: [
                    { required: true, message: '请输入字典编码' },
                    { max: 50, message: '不能超过50个字符' }
                ]
            },
            statusCheck: { initialValue: true }
        }
    },

    methods: {
        edit(id) {
            this.editList.id = id
            this.visible = true
            this.getInfo()
            this.form.resetFields()
        },

        // 获取该id信息
        getInfo() {
            axios.get('Dictype/' + this.editList.id).then(res => {
                this.editList = res.data
                this.nameCheck.initialValue = res.data.name
                this.codeCheck.initialValue = res.data.code
                this.statusCheck.initialValue = res.data.status
            })
        },

        handleSubmit() {
            this.confirmLoading = true
            this.form.validateFields((err, values) => {
                if (!err) {
                    let data = {
                        name: values.name,
                        code: values.code,
                        status: values.status,
                        id: this.editList.id,
                        version: this.editList.version
                    }
                    axios.put('DicType/', data).then(res => {
                        setTimeout(() => {
                            this.$message.success(`${values.name} 修改成功`)
                            this.visible = false
                            this.confirmLoading = false
                            this.$emit('query', values)
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
