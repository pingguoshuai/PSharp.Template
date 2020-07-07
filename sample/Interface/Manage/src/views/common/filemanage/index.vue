<template>
    <div class="page">
        <a-card :bordered="false">
            <!-- S 查询 -->
            <div class="table-page-search-wrapper">
                <a-form layout="inline">
                    <a-row :gutter="48">
                        <a-col :md="8" :sm="24">
                            <a-form-item label="旧文件名">
                                <a-input v-model="queryParam.oldName" placeholder="请输入查询旧文件名" />
                            </a-form-item>
                        </a-col>
                        <a-col :md="8" :sm="24">
                            <a-form-item label="新文件名">
                                <a-input v-model="queryParam.newName" placeholder="请输入查询新文件名" />
                            </a-form-item>
                        </a-col>
                        <a-col :md="8" :sm="24">
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
                :dataSource="dataList"
                :pagination="pagination"
                @change="handleTableChange"
                bordered
                rowKey="id"
            >
                <a-table-column title="旧文件名" data-index="oldName" />
                <a-table-column title="新文件名" data-index="newName" />
                <a-table-column title="扩展" data-index="extension" />
                <!-- <a-table-column title="附件" data-index="src" /> -->
                <a-table-column title="预览" data-index="src">
                    <template slot-scope="src">
                        <a-avatar class="preview" :src="url + src" size="large" shape="square" />
                    </template>
                </a-table-column>
                <a-table-column title="创建日期" data-index="creationTime">
                    <template slot-scope="scope, record">{{ record.creationTime }}</template>
                </a-table-column>
                <a-table-column title="操作" data-index="operation">
                    <template slot-scope="text, record">
                        <div class="editable-row-operations" slot="operation">
                            <span v-if="record.editable">
                                <a @click="() => save(record.key)">保存</a>
                                <a-popconfirm title="确认取消？" @confirm="() => cancel(record.key)">
                                    <a>取消</a>
                                </a-popconfirm>
                            </span>
                            <span v-else>
                                <!-- <a @click="$refs.editModal.edit(record)">修改</a>
                                <a-divider type="vertical" /> -->
                                <a-popconfirm
                                    title="确定要删除这行数据吗?"
                                    placement="topLeft"
                                    @confirm="handleDel(record)"
                                >
                                    <a>删除</a>
                                </a-popconfirm>
                            </span>
                        </div>
                    </template>
                </a-table-column>
            </a-table>
            <create-form ref="createModal" @ok="handleQuery" />
            <edit-form ref="editModal" @ok="handleQuery" />
            <!-- E 表格 -->
        </a-card>
    </div>
</template>

<script>
import { axios } from '@/utils/request'
import CreateForm from './add'
import EditForm from './edit'
import moment from 'moment'
import { formatDate } from '@/utils/date'

export default {
    name: 'filemanage',
    components: {
        CreateForm,
        EditForm
    },
    data() {
        return {
            url: 'http://192.168.20.207:9004/',
            dataList: [],
            pagination: {
                total: 1,
                showSizeChanger: true,
                pageSize: 10,
                current: 1
            },
            queryParam: {
                page: 0,
                pageSize: 0,
                oldName: '',
                newName: ''
            },
            loading: true
        }
    },

    filters: {
        formatDate(time) {
            let date = new Date(time)
            return formatDate(date)
        }
    },
    created() {
        this.queryParam.page = this.pagination.current
        this.queryParam.pageSize = this.pagination.pageSize
        this.getDataList()
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
            axios.get('SysFile/', { params }).then(res => {
                this.pagination.current = res.data.page
                this.pagination.pageSize = res.data.pageSize
                this.pagination.total = res.data.totalCount
                this.dataList = res.data.data
                this.loading = false
            })
        },

        confirm() {
            message.info('Clicked on Yes.')
        },

        // 删除
        handleDel(record) {
            axios.delete('SysFile/' + record.id).then(res => {
                if (res.data) {
                    this.$message.info(`${record.oldName} 删除成功`)
                } else {
                    this.$message.error(`${record.oldName} 删除失败`)
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

<style>
.preview {
    width: 120px;
    height: auto;
}
</style>



