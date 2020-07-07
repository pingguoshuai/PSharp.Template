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
                        <a-form-item label="字典编码">
                            <a-input v-model="queryParam.code" placeholder="请输入查询字典编码" />
                        </a-form-item>
                    </a-col>
                    <a-col :md="6" :sm="24">
                        <a-form-item label="是否启用">
                            <a-select v-model="queryParam.status" placeholder="请选择启用状态" defaultValue="1">
                                <a-select-option value="all">全部</a-select-option>
                                <a-select-option value="true">启用</a-select-option>
                                <a-select-option value="false">禁用</a-select-option>
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
            :pagination="pagination"
            @change="handleTableChange"
            bordered
            rowKey="id"
        >
            <a-table-column title="名称" data-index="name" />
            <a-table-column title="字典编码" data-index="code" />
            <a-table-column title="是否启用" data-index="status">
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
                        <a-divider type="vertical" />
                        <a-popconfirm title="确认取消？" @confirm="() => cancel(record.key)">
                            <a>取消</a>
                        </a-popconfirm>
                    </span>
                    <span v-else>
                        <a @click="$refs.editModal.edit(record.id)">修改</a>
                        <a-divider type="vertical" />
                        <a-popconfirm title="确定要删除这行数据吗?" placement="topLeft" @confirm="handleDel(record)">
                            <a>删除</a>
                        </a-popconfirm>
                    </span>
                </template>
            </a-table-column>
        </a-table>
        <create-form ref="createModal" @query="handleQuery" />
        <edit-form ref="editModal" @query="handleQuery" />
        <!-- E 表格 -->
    </a-card>
</template>

<script>
import { axios } from '@/utils/request'
import CreateForm from './add'
import EditForm from './edit'
import moment from 'moment'

export default {
    name: 'dictype',
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
            queryParam: {},
            loading: true
        }
    },
    created() {
        this.queryParam.page = this.pagination.current
        this.queryParam.pageSize = this.pagination.pageSize
        this.getDataList()
    },

    mounted() {},

    methods: {
        // 获取列表数据
        getDataList() {
            this.loading = true
            let params = Object.assign({}, this.queryParam)
            for (let i in params) {
                params[i] == 'all' && (params[i] = '')
                if (params[i] == '') {
                    delete params[i]
                }
            }
            axios.get('Dictype', { params }).then(res => {
                this.pagination.current = res.data.page
                this.pagination.pageSize = res.data.pageSize
                this.pagination.total = res.data.totalCount
                this.tableList = res.data.data
                this.loading = false
            })
        },

        // 删除
        handleDel(record) {
            axios.delete('DicType/' + record.id).then(res => {
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
        handleTableChange(res) {
            this.queryParam.page = res.current
            this.queryParam.pageSize = res.pageSize
            this.getDataList()
        }
    }
}
</script>

<style code>
.editable-row-operations a {
    margin-right: 8px;
}
</style>