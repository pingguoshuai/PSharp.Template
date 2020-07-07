
<template>
    <a-modal
        title="医院"
        :width="640"
        :visible="visible"
        :confirmLoading="confirmLoading"
        @ok="handleSubmit"
        @cancel="handleCancel"
    >
        <a-spin :spinning="confirmLoading">
            <a-form :form="form">
                <a-form-item label="医院名称" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-input placeholder="请输入医院名称"
                        v-decorator="[
                            'name',
                            {
                                rules: [
                                    { max: 200, message: '不能超过200个字符' },
                                    { required: true, message: '请输入名称' }
                                ]
                            }
                        ]"
                    />
                </a-form-item>
                <a-form-item label="医院简称" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-input placeholder="请输入医院简称" v-decorator="['abbreviation', { rules: [{ max: 100, message: '不能超过100个字符' }] }]" />
                </a-form-item>
                <a-form-item label="医院编码" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-input placeholder="请输入医院编码"
                        v-decorator="[
                            'code',
                            {
                                rules: [
                                    { max: 50, message: '不能超过50个字符' },
                                    { required: true, message: '请输入医院编码' }
                                ]
                            }
                        ]"
                    />
                </a-form-item>
                <a-form-item label="医院排序" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-input-number placeholder="请输入医院排序"
                        v-decorator="[
                            'sortId',
                            { rules: [{ type: 'number', message: '请输入正确的排序' }], initialValue: '' }
                        ]"
                    />
                </a-form-item>
                <a-form-item label="启用" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-switch v-decorator="['enabled', { valuePropName: 'checked', initialValue: true }]" />
                </a-form-item>
            </a-form>
        </a-spin>
    </a-modal>
</template>

<script>
import { axios } from '@/utils/request'
import pick from 'lodash.pick'

export default {
    props: {
        afterSubmit: {
            type: Function,
            default: null
        }
    },
    data() {
        return {
            form: this.$form.createForm(this),
            labelCol: { xs: { span: 24 }, sm: { span: 7 } },
            wrapperCol: { xs: { span: 24 }, sm: { span: 13 } },
            visible: false,
            confirmLoading: false,
            entity: {},
            isadd: true
        }
    },
    methods: {
        add() {
            this.visible = true
            this.isadd = true
            this.form.resetFields()
            this.entity = {}
        },
        edit(id) {
            this.visible = true
            this.isadd = false
            this.entity = {}
            this.$nextTick(() => {
                this.form.resetFields()
                var formFields = this.form.getFieldsValue()
                this.confirmLoading = true
                axios
                    .get('Hospital/' + id)
                    .then(res => {
                        this.entity = res.data
                        var setData = {}
                        Object.keys(formFields).forEach(item => {
                            setData[item] = this.entity[item]
                        })
                        this.form.setFieldsValue(setData)
                        this.confirmLoading = false
                    })
                    .catch(errors => {
                        this.confirmLoading = false
                    })
            })
        },
        handleSubmit() {
            this.form.validateFields((errors, values) => {
                if (!errors) {
                    let entity = Object.assign(this.entity, this.form.getFieldsValue())
                    this.confirmLoading = true
                    if (this.isadd) {
                        axios
                            .post('Hospital', entity)
                            .then(res => {
                                this.visible = false
                                this.confirmLoading = false
                                this.afterSubmit()
                            })
                            .catch(errors => {
                                this.confirmLoading = false
                            })
                    } else {
                        axios
                            .put('Hospital', entity)
                            .then(res => {
                                this.visible = false
                                this.confirmLoading = false
                                this.afterSubmit()
                            })
                            .catch(errors => {
                                this.confirmLoading = false
                            })
                    }
                }
            })
        },
        handleCancel() {
            this.visible = false
        }
    }
}
</script>

