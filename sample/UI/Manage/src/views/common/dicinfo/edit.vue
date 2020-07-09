<template>
    <a-modal
        title="修改参数"
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
            </a-form>
            <a-form :form="form">
                <a-form-item label="字典值" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-input name="value" placeholder="请输入字典值" v-decorator="['value', valueCheck]" />
                </a-form-item>
            </a-form>
            <a-form :form="form">
                <a-form-item label="类型" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-select placeholder="请选择字典类型" v-decorator="['dicTypeId', dictypeCheck]">
                        <a-select-option v-for="(item, index) in dicTypeList" :value="item.id" :key="index">
                            {{ item.name }}
                        </a-select-option>
                    </a-select>
                </a-form-item>
            </a-form>
            <a-form :form="form">
                <a-form-item label="排序" :labelCol="labelCol" :wrapperCol="wrapperCol">
                    <a-input-number
                        placeholder="请输入字典排序"
                        v-decorator="['sort', sortCheck]"
                        :min="0"
                        :max="1000"
                    />
                </a-form-item>
            </a-form>
            <a-form :form="form">
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
            editList: {},
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
                initialValue: ''
            },
            statusCheck: { initialValue: null }
        }
    },

    mounted() {
        this.form.setFieldsValue({
            typeId: this.editList.dicTypeName
        })
    },

    methods: {
        // 获取type类型信息
        getDataList() {
            axios.get('Dictype/').then(res => {
                this.dicTypeList = res.data.data
            })
        },

        edit(id) {
            this.editList.id = id
            // this.editList.id = 'e2d29d94-fa25-48a9-8ade-96c1b43028d5'
            this.visible = true
            this.getDataList()
            this.getInfo()
            this.form.resetFields()
        },

        // 获取id信息
        getInfo() {
            axios.get('DicInfo/' + this.editList.id).then(res => {
                this.editList = res.data
                this.nameCheck.initialValue = res.data.name
                this.valueCheck.initialValue = res.data.value
                this.dictypeCheck.initialValue = res.data.dicTypeId
                this.sortCheck.initialValue = res.data.sort
                this.statusCheck.initialValue = res.data.status
            })
        },

        // 确定提交
        handleSubmit() {
            this.confirmLoading = true
            this.form.validateFields((errors, values) => {
                if (!errors) {
                    let data = {
                        name: values.name,
                        code: values.code,
                        status: values.status,
                        dicTypeId: values.dicTypeId,
                        sort: values.sort,
                        id: this.editList.id,
                        version: this.editList.version
                    }
                    axios.put('DicInfo/', data).then(res => {
                        setTimeout(() => {
                            this.$message.success(`${values.name} 修改成功`)
                            this.visible = false
                            this.confirmLoading = false
                            this.$emit('ok', values)
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
