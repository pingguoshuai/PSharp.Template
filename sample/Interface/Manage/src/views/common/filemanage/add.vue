<template>
    <a-modal
        title="新建文件"
        :width="640"
        :visible="visible"
        :confirmLoading="uploading"
        :destroyOnClose="true"
        @ok="handleUpload"
        @cancel="handleCancel"
        style="margin-top: 16px"
    >
        <a-spin :spinning="uploading">
            <a-form :form="form">
                <a-form-item label="文件" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-upload
                        :multiple="true"
                        list-type="picture"
                        :defaultFileList="fileList"
                        :remove="handleRemove"
                        :beforeUpload="beforeUpload"
                    >
                        <a-button><a-icon type="upload" />点击上传</a-button>
                    </a-upload>
                </a-form-item>
            </a-form>
        </a-spin>
    </a-modal>
</template>

<script>
import { axios } from '@/utils/request'
import reqwest from 'reqwest'
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
            form: this.$form.createForm(this),
            fileList: [],
            uploading: false
        }
    },

    methods: {
        add() {
            this.visible = true
            this.form.resetFields()
        },
        // 提交
        handleUpload() {
            let fileList = this.fileList
            if (fileList.length === 0) {
                this.$message.info('请选择上传文件')
                return
            }
            let formData = new FormData()
            fileList.forEach(file => {
                formData.append('file', file)
            })
            this.uploading = true
            axios
                .post('SysFile/Upload', formData)
                .then(res => {
                    this.fileList = []
                    this.uploading = false
                    this.visible = false
                    this.$message.success('上传成功')
                    this.$emit('ok', formData)
                })
                .catch(err => {
                    this.fileList = []
                    this.uploading = false
                    // this.$message.error('上传失败')
                })
        },
        // 取消提交
        handleCancel() {
            this.fileList = []
            this.visible = false
        },
        handleRemove(file) {
            let index = this.fileList.indexOf(file)
            let newFileList = this.fileList.slice()
            newFileList.splice(index, 1)
            this.fileList = newFileList
        },
        beforeUpload(file) {
            this.fileList = [...this.fileList, file]
            return false
        }
    }
}
</script>