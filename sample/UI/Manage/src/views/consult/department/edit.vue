
<template>
    <a-modal
        title="科室"
        :width="640"
        :visible="visible"
        :confirmLoading="confirmLoading"
        :destroyOnClose="true"
        @ok="handleSubmit"
        @cancel="handleCancel"
    >
        <a-spin :spinning="confirmLoading">
            <a-form :form="form">
                <a-form-item label="科室名称" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-input placeholder="请输入科室名称" v-decorator="['name', nameCheck]" />
                </a-form-item>
                <a-form-item label="科室编码" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-input placeholder="请输入科室编码" v-decorator="['code', codeCheck]" />
                </a-form-item>
                <a-form-item label="科室图标" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-upload
                        :multiple="true"
                        list-type="picture-card"
                        :defaultFileList="fileList"
                        :remove="handleRemove"
                        :beforeUpload="beforeUpload"
                        :showUploadList="{ showPreviewIcon: false }"
                    >
                        <img v-if="entity.iconSrc" :src="entity.iconSrc" alt="avatar" />
                        <div v-else-if="fileList.length < 1">
                            <a-icon type="plus" />
                            <div class="ant-upload-text">
                                点击上传
                            </div>
                        </div>
                    </a-upload>
                </a-form-item>
                <a-form-item label="科室排序" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-input-number placeholder="请输入科室排序" v-decorator="['sortId', sortCheck]" :min="0" />
                </a-form-item>
                <a-form-item label="是否启用" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-switch v-decorator="['enabled', enabledCheck]" />
                </a-form-item>
            </a-form>
        </a-spin>
    </a-modal>
</template>

<script>
import { axios } from '@/utils/request'
import pick from 'lodash.pick'
import { ACCESS_TOKEN } from '@/store/mutation-types'

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
            isadd: true,
            fileList: [],
            nameCheck: {
                initialValue: '',
                rules: [
                    { max: 50, message: '不能超过50个字符' },
                    { required: true, message: '请输入名称' }
                ]
            },
            codeCheck: {
                initialValue: '',
                rules: [
                    { max: 50, message: '不能超过50个字符' },
                    { required: true, message: '请输入科室编码' }
                ]
            },
            enabledCheck: { valuePropName: 'checked', initialValue: true },
            sortCheck: { initialValue: '', rules: [{ type: 'number', message: '请输入正确的排序' }] }
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
                    .get('Department/' + id)
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
            this.confirmLoading = true
            this.form.validateFields((errors, values) => {
                if (!errors) {
                    let entity = Object.assign(this.entity, this.form.getFieldsValue())
                    if (!!entity.icon && entity.icon != entity.iconId) {
                        entity.iconId = entity.icon
                    }
                    delete entity.icon
                    if (this.isadd) {
                        axios
                            .post('Department', entity)
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
                            .put('Department', entity)
                            .then(res => {
                                this.visible = false
                                this.confirmLoading = false
                                this.afterSubmit()
                            })
                            .catch(errors => {
                                this.confirmLoading = false
                            })
                    }
                } else {
                    this.confirmLoading = false
                }
            })
        },
        handleCancel() {
            this.visible = false
        },
        handleRemove(file) {
            // let index = this.fileList.indexOf(file)
            // let newFileList = this.fileList.slice()
            // newFileList.splice(index, 1)
            // this.fileList = newFileList
            this.fileList = []
        },
        beforeUpload(file) {
            // this.fileList = [...this.fileList, file]
            this.fileList = [file]
            let formData = new FormData()
            formData.append('file', file)
            this.confirmLoading = true
            axios.post('SysFile/Upload', formData).then(res => {
                this.entity.icon = res.data.id
                this.confirmLoading = false
                this.$message.success('上传成功')
                this.$emit('ok', formData)
            })
            return false
        }
    }
}
</script>

