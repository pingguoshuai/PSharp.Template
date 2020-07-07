<template>
    <a-card :bordered="false">
        <!-- S 查询 -->
        <div class="table-page-search-wrapper">
            <a-form layout="inline">
                <a-row :gutter="48">
                    <a-col :md="6" :sm="24">
                        <a-form-item label="名称">
                            <a-input v-model="queryParam.name" placeholder="请输入查询名称" />
                        </a-form-item>
                    </a-col>
                    <a-col :md="6" :sm="24">
                        <a-form-item label="字典值">
                            <a-input v-model="queryParam.value" placeholder="请输入查询字典值" />
                        </a-form-item>
                    </a-col>
                    <a-col :md="6" :sm="24">
                        <a-form-item label="字典类型">
                            <a-select v-model="queryParam.dicTypeId" placeholder="请选择字典类型" defaultValue="1">
                                <a-select-option v-for="(item, index) in typeList" :value="item.id" :key="index">
                                    {{ item.name }}
                                </a-select-option>
                            </a-select>
                        </a-form-item>
                    </a-col>
                    <a-col :md="6" :sm="24">
                        <span class="table-page-search-submitButtons">
                            <a-button type="primary" @click="handleQuery">查询</a-button>
                            <a-button style="margin-left: 8px" @click="handleReset">重置</a-button>
                        </span>
                    </a-col>
                </a-row>
            </a-form>
        </div>
        <!-- E 查询 -->

        <!-- S 新建 -->
        <div class="table-operator">
            <a-button type="primary" icon="plus" @click="$refs.createModal.add()">新建</a-button>
        </div>
        <!-- E 新建 -->

        <!-- S 表格 -->
        <a-table
            :dataSource="tableList"
            :typeList="typeList"
            :pagination="pagination"
            @change="handleTableChange"
            bordered
            rowKey="id"
        >
            <a-table-column title="名称" data-index="name" />
            <a-table-column title="字典值" data-index="value" />
            <a-table-column title="类型" data-index="dicTypeName" />
            <a-table-column title="启用" data-index="status">
                <template slot-scope="status">
                    <span>
                        <a-tag v-if="status" color="blue">是</a-tag>
                        <a-tag v-else color="orange">否</a-tag>
                    </span>
                </template>
            </a-table-column>

            <a-table-column title="操作" data-index="operation">
                <template slot-scope="text, record">
                    <span v-if="record.editable">
                        <a @click="() => save(record.key)">保存</a>
                        <a-popconfirm title="确认取消？" @confirm="() => cancel(record.key)">
                            <a>取消</a>
                        </a-popconfirm>
                    </span>
                    <span v-else>
                        <a @click="$refs.editModal.edit(record.id)">修改</a>
                        <a-divider type="vertical" />
                        <a-popconfirm title="确定要删除这行数据吗？" placement="topLeft" @confirm="handleDel(record)">
                            <a>删除</a>
                        </a-popconfirm>
                    </span>
                </template>
            </a-table-column>
        </a-table>
        <create-form ref="createModal" @ok="handleQuery" />
        <edit-form ref="editModal" @ok="handleQuery" />
        <!-- E 表格 -->
    </a-card>
</template>

<script>
import { axios } from '@/utils/request'
import moment from 'moment'
import CreateForm from './add'
import EditForm from './edit'

export default {
    name: 'dicinfo',
    components: {
        CreateForm,
        EditForm
    },

    data() {
        return {
            tableList: [],
            pagination: {
                total: 1,
                showSizeChanger: true,
                pageSize: 10,
                current: 1
            },
            queryParam: {
                page: 0,
                pageSize: 0,
            },
            typeList: [],
            loading: true
        }
    },

    filters: {},
    created() {
        this.queryParam.page = this.pagination.current
        this.queryParam.pageSize = this.pagination.pageSize
        this.getDataList()
        this.getTypeList()
    },

    methods: {
        // 表格数据渲染
        getDataList() {
            this.loading = true
            let params = Object.assign({}, this.queryParam)
            for (let i in params) {
                params[i] == 'all' && (params[i] = '')
                if (params[i] == '') {
                    delete params[i]
                }
            }
            axios.get('DicInfo', { params }).then(res => {
                this.pagination.current = res.data.page
                this.pagination.total = res.data.totalCount
                this.pagination.pageSize = res.data.pageSize
                this.tableList = res.data.data
                this.loading = false
            })
        },

        // 获取类型
        getTypeList() {
            axios.get('Dictype').then(res => {
                this.typeList = res.data.data
                this.typeList.unshift({
                    id: 'all',
                    name: '全部'
                })
            })
        },

        // 删除该行数据
        handleDel(record) {
            axios.delete('DicInfo/' + record.id).then(res => {
                if (res.data) {
                    this.$message.info(`${record.code} 删除成功`)
                } else {
                    this.$message.error(`${record.code} 删除失败`)
                }
                this.getDataList()
            })
        },

        // 查询
        handleQuery() {
            this.getDataList()
        },
        // 重置
        handleReset() {
            this.queryParam = {}
            this.queryParam.page = this.pagination.current
            this.queryParam.pageSize = this.pagination.pageSize
            this.handleQuery()
        },

        // 搜索没有数据时，提示框
        showConfirm() {
            this.$confirm({
                title: '没有搜索结果，请重新输入',
                content: h => <div style="color:red;"></div>,
                onOk() {
                    // console.log('OK');
                },
                onCancel() {
                    // console.log('Cancel');
                },
                class: 'test'
            })
        },

        // 分页函数
        handleTableChange(pagination) {
            this.pagination.pageNo = pagination.current
            this.pagination.pageSize = pagination.pageSize
            this.getDataList()
        }
    }
}
</script>
