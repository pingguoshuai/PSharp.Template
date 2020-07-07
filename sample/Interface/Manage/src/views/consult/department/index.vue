

<template>
    <a-card :bordered="false">
        <div class="table-page-search-wrapper">
            <a-form layout="inline">
                <a-row :gutter="48">
                    <a-col :md="6" :sm="24">
                        <a-form-item label="科室名称">
                            <a-input v-model="queryParam.name" placeholder="请输入科室名称" />
                        </a-form-item>
                    </a-col>
                    <a-col :md="6" :sm="24">
                        <a-form-item label="科室编码">
                            <a-input v-model="queryParam.code" placeholder="请输入科室编码" />
                        </a-form-item>
                    </a-col>
                    <a-col :md="6" :sm="24">
                        <a-form-item label="是否启用">
                            <a-select v-model="queryParam.enabled" placeholder="请选择启用状态" defaultValue="1">
                                <a-select-option value="all">全部</a-select-option>
                                <a-select-option value="true">启用</a-select-option>
                                <a-select-option value="false">禁用</a-select-option>
                            </a-select>
                        </a-form-item>
                    </a-col>
                    <a-col :md="6" :sm="24">
                        <span class="table-page-search-submitButtons">
                            <!-- :style="advanced && { float: 'right', overflow: 'hidden' } || {} " -->
                            <a-button type="primary" @click="handleQuery">查询</a-button>
                            <a-button style="margin-left: 8px" @click="handleReset">重置</a-button>
                        </span>
                    </a-col>
                </a-row>
            </a-form>
        </div>

        <div class="table-operator">
            <a-button type="primary" icon="plus" @click="handleAdd">新建</a-button>
        </div>

        <a-table
            :dataSource="tableList"
            :pagination="pagination"
            @change="handleTableChange"
            rowKey="id"
        >
            <a-table-column title="科室名称" dataIndex="name" />
            <a-table-column title="科室编码" dataIndex="code" />
            <!-- <a-table-column title="图标" dataIndex="iconId" /> -->
            <a-table-column title="科室图标" dataIndex="iconSrc">
                <template slot-scope="iconSrc">
                    <a-avatar :src="iconSrc" size="large" shape="square" />
                </template>
            </a-table-column>
            <a-table-column title="科室排序" dataIndex="sortId" />
            <a-table-column title="启用" dataIndex="enabled">
                <template slot-scope="enabled">
                    <span>
                        <a-tag v-if="enabled" color="blue">是</a-tag>
                        <a-tag v-else color="orange">否</a-tag>
                    </span>
                </template>
            </a-table-column>
            <a-table-column title="操作" key="action">
                <template slot-scope="text, record">
                    <span>
                        <a @click="handleDetail(record)">详情</a>
                        <a-divider type="vertical" />
                        <a @click="handleEdit(record)">编辑</a>
                        <a-divider type="vertical" />
                        <a-popconfirm title="确定要删除这行数据吗?" placement="topLeft" @confirm="handleDel(record)">
                            <template slot="title">
                                <p>取消</p>
                                <p>确定</p>
                            </template>
                            <a>删除</a>
                        </a-popconfirm>
                    </span>
                </template>
            </a-table-column>
        </a-table>
        <edit-form ref="editModal" :afterSubmit="handleQuery" />
        <detail-form ref="detailModal" />
    </a-card>
</template>

<script>
import moment from 'moment'
import EditForm from './edit'
import DetailForm from './detail'
import { axios } from '@/utils/request'

export default {
    name: 'department',
    components: {
        EditForm,
        DetailForm
    },
    data() {
        return {
            loading: true,
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
            }
        }
    },
    created() {
        this.queryParam.page = this.pagination.current
        this.queryParam.pageSize = this.pagination.pageSize
        this.getDataList()
    },
    mounted() {},
    methods: {
        getDataList() {
            this.loading = true
            let params = Object.assign({}, this.queryParam)
            for (let i in params) {
                params[i] == 'all' && (params[i] = '')
                if (params[i] == '') {
                    delete params[i]
                }
            }
            axios
                .get('Department', { params })
                .then(res => {
                    this.pagination.current = res.data.page
                    this.pagination.pageSize = res.data.pageSize
                    this.pagination.total = res.data.totalCount
                    this.tableList = res.data.data
                    this.loading = false
                })
                .catch(errors => {
                    this.loading = false
                })
        },
        // 删除
        handleDel(record) {
            axios.delete('Department/' + record.id).then(res => {
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
        // 分页函数
        handleTableChange(res) {
            this.queryParam.page = res.current
            this.queryParam.pageSize = res.pageSize
            this.getDataList()
        },
        handleAdd() {
            this.$refs.editModal.add()
        },
        handleEdit(msg) {
            this.$refs.editModal.edit(msg.id)
        },
        handleDetail(msg) {
            this.$refs.detailModal.detail(msg)
        }
    }
}
</script>
