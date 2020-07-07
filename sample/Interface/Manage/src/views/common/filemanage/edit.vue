<template>
    <a-modal
        title="修改"
        :width="640"
        :visible="visible"
        :confirmLoading="confirmLoading"
        @ok="handleSubmit"
        @cancel="handleCancel"
    >
        <a-spin :spinning="confirmLoading">
            <a-form :form="form">
                <a-form-item label="路径" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <!-- <a-upload
                        name="file"
                        :multiple="true"
                        action="https://www.mocky.io/v2/5cc8019d300000980a055e76"
                        :headers="headers"
                        @change="handleChange"
                    >
                        <a-button> <a-icon type="upload" />点击上传 </a-button>
                    </a-upload> -->
                    <a-upload :fileList="fileList" :remove="handleRemove" :beforeUpload="beforeUpload">
                        <a-button><a-icon type="upload" />点击上传</a-button>
                    </a-upload>
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
            // headers: {
            //     authorization: 'authorization-text'
            // },
            info: '',
            extension: '',
            fileList: []
        }
    },

    methods: {
        edit(record) {
            this.editList = record
            this.visible = true
        },
        handleSubmit() {
            const {
                form: { validateFields }
            } = this
            this.confirmLoading = true
            validateFields((errors, values) => {
                if (!errors) {
                    console.log('values', values)
                    axios
                        .put('SysFile/', {
                            extension: values.extension,
                            src: values.src,
                            oldName: this.editList.oldName,
                            newName: this.editList.newName,
                            size: this.editList.sort,
                            md5: this.editList.md5,
                            id: this.editList.id,
                            version: this.editList.version
                        })
                        .then(res => {
                            console.log(res)
                        })
                    setTimeout(() => {
                        this.visible = false
                        this.confirmLoading = false
                        this.$emit('ok', values)
                    }, 1500)
                } else {
                    this.confirmLoading = false
                }
            })
        },
        handleCancel() {
            this.visible = false
        },
        // 上传
        handleChange(info) {
            if (info.file.status !== 'uploading') {
                this.info = info.file
                this.extension = this.info.name.split('.')[1]
                console.log('info.file-->', info.file)
                console.log('info.fileList-->', info.fileList)
            }
            if (info.file.status === 'done') {
                this.$message.success(`${info.file.name} file uploaded successfully`)
            } else if (info.file.status === 'error') {
                this.$message.error(`${info.file.name} file upload failed.`)
            }
        },
        handleRemove(file) {
            const index = this.fileList.indexOf(file)
            const newFileList = this.fileList.slice()
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
