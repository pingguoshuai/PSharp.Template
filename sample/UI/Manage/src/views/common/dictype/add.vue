<template>
    <a-modal
        title="新建字典"
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
                    <a-switch v-model="status" v-decorator="['status', statusCheck]" />
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
            status: true,
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
        add() {
            this.visible = true
            this.form.resetFields()
        },
        // 提交
        handleSubmit() {
            this.confirmLoading = true
            this.form.validateFields((errors, values) => {
                // console.log(errors, values)
                if (!errors) {
                    let data = {
                        name: values.name,
                        code: values.code,
                        status: values.status
                    }
                    axios.post('DicType', data).then(res => {
                        // console.log(res)
                        setTimeout(() => {
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
        // 取消提交
        handleCancel() {
            this.visible = false
        }
    }
}
</script>

<style>
</style>
