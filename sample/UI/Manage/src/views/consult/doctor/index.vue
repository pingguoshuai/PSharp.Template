

<template>
    <a-card :bordered="false">
        <div class="table-page-search-wrapper">
            <a-form layout="inline">
                <a-row :gutter="48">
                    <a-col :md="8" :sm="24">
                        <a-form-item label="医生姓名">
                            <a-input v-model="queryParam.name" placeholder="请输入医生姓名" />
                        </a-form-item>
                    </a-col>
                    <a-col :md="8" :sm="24">
                        <a-form-item label="医生手机">
                            <a-input v-model="queryParam.phoneNumber" placeholder="请输入医生手机号" />
                        </a-form-item>
                    </a-col>
                    <a-col :md="8" :sm="24">
                        <a-form-item label="医生职称">
                            <a-input v-model="queryParam.title" placeholder="请输入医生职称" />
                        </a-form-item>
                    </a-col>
                    <a-col :md="8" :sm="24">
                        <a-form-item label="医院名称">
                            <a-select v-model="queryParam.hospitalId" placeholder="请选择医院名称" defaultValue="1">
                                <a-select-option v-for="(item, index) in hospitalList" :value="item.id" :key="index">
                                    {{ item.name }}
                                </a-select-option>
                            </a-select>
                        </a-form-item>
                    </a-col>
                    <a-col :md="8" :sm="24">
                        <a-form-item label="科室名称">
                            <a-select v-model="queryParam.departmentName" placeholder="请选择科室名称" defaultValue="1">
                                <a-select-option v-for="(item, index) in departmentList" :value="item.id" :key="index">
                                    {{ item.name }}
                                </a-select-option>
                            </a-select>
                        </a-form-item>
                    </a-col>
                    <a-col :md="8" :sm="24">
                        <a-form-item label="审核状态">
                            <a-select v-model="queryParam.auditId" placeholder="请选择审核状态" defaultValue="1">
                                <a-select-option v-for="(item, index) in auditList" :value="item.id" :key="index">
                                    {{ item.name }}
                                </a-select-option>
                            </a-select>
                        </a-form-item>
                    </a-col>
                    <a-col :md="8" :sm="24">
                        <a-form-item label="是否启用">
                            <a-select v-model="queryParam.enabled" placeholder="请选择启用状态" defaultValue="1">
                                <a-select-option value="all">全部</a-select-option>
                                <a-select-option value="true">启用</a-select-option>
                                <a-select-option value="false">禁用</a-select-option>
                            </a-select>
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

        <!-- <div class="table-operator">
      <a-button type="primary" icon="plus" @click="handleAdd">新建</a-button>
    </div> -->

        <a-table
            :dataSource="tableList"
            :pagination="pagination"
            @change="handleTableChange"
            rowKey="id"
        >
            <a-table-column title="医生姓名" dataIndex="name" />
            <a-table-column title="医生头像" dataIndex="doctorMemberHeadImgSrc">
                <template slot-scope="doctorMemberHeadImgSrc">
                    <a-avatar :src="doctorMemberHeadImgSrc" size="large" shape="square" />
                </template>
            </a-table-column>
            <a-table-column title="医院名称" dataIndex="hospitalName" />
            <a-table-column title="科室名称" dataIndex="departmentName" />
            <a-table-column title="手机号" dataIndex="phoneNumber" />
            <a-table-column title="医生职称" dataIndex="title" />
            <!-- <a-table-column title="关注量" dataIndex="followNum" /> -->
            <a-table-column title="医生咨询量" dataIndex="consultNum" />
            <!-- <a-table-column title="医生评分" dataIndex="score" /> -->
            <a-table-column title="审核状态" dataIndex="auditName" />
            <a-table-column title="状态" dataIndex="enabled">
                <template slot-scope="enabled">
                    <span>
                        <a-tag v-if="enabled" color="blue">启用</a-tag>
                        <a-tag v-else color="orange">禁用</a-tag>
                    </span>
                </template>
            </a-table-column>

            <a-table-column title="操作" key="action">
                <template slot-scope="text, record">
                    <span>
                        <a @click="handleDetail(record)">详情</a>
                        <a-divider type="vertical" />
                        <a @click="handleExamine(record)">审核</a>
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
        <examine-form ref="examineModal" :afterSubmit="handleQuery" />
    </a-card>
</template>

<script>
import moment from 'moment'
import EditForm from './edit'
import DetailForm from './detail'
import ExamineForm from './examine'
import { axios } from '@/utils/request'

export default {
    name: 'department',
    components: {
        EditForm,
        DetailForm,
        ExamineForm
    },
    data() {
        return {
            loading: true,
            tableList: [],
            auditList: [],
            hospitalList: [],
            departmentList: [],
            allData: { id: 'all', name: '全部' },
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
        this.getAuditList()
        this.getHospitalList()
        this.getDepartmentList()
        this.getDataList()
    },
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
                .get('Doctor', { params })
                .then(res => {
                    this.pagination.current = res.data.page
                    this.pagination.pageSize = res.data.pageSize
                    this.pagination.total = res.data.totalCount
                    this.tableList = res.data.data
                    this.loading = false
                })
                .catch(() => {
                    this.loading = false
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
        // 添加
        handleAdd() {
            this.$refs.editModal.add()
        },
        // 修改
        handleEdit(msg) {
            let data = {
                id: msg.id,
                auditList: this.auditList.slice(1),
                hospitalList: this.hospitalList.slice(1),
                departmentList: this.departmentList.slice(1)
            }
            this.$refs.editModal.edit(data)
        },
        // 审核
        handleExamine(msg) {
            let data = {
                id: msg.id,
                auditList: this.auditList.slice(1),
                hospitalList: this.hospitalList.slice(1),
                departmentList: this.departmentList.slice(1)
            }
            this.$refs.examineModal.examine(data)
        },
        // 详情
        handleDetail(msg) {
            this.$refs.detailModal.detail(msg)
        },
        // 删除
        handleDel(msg) {
            axios.delete('Doctor/' + msg.id).then(res => {
                this.$message.info(`删除成功`)
                this.getDataList()
            })
        },
        // 获取审核状态
        getAuditList() {
            axios.get('DicInfo/GetListByTypeCode?code=Audit').then(res => {
                this.auditList = res.data
                this.auditList.unshift(this.allData)
            })
        },
        // 获取医院
        getHospitalList() {
            axios.get('Hospital', { params: { page: 1, pageSize: 10 } }).then(res => {
                this.hospitalList = res.data.data
                this.hospitalList.unshift(this.allData)
            })
        },
        // 获取科室
        getDepartmentList() {
            axios.get('Department', { params: { page: 1, pageSize: 10 } }).then(res => {
                this.departmentList = res.data.data
                this.departmentList.unshift(this.allData)
            })
        }
    }
}
</script>
