

<template>
  <a-card :bordered="false">
    <div class="table-page-search-wrapper">
      <a-form layout="inline">
        <a-row :gutter="48">
            
          <a-col :md="8" :sm="24">
            <a-form-item label="栏目ID">
              <a-input v-model="queryParam.columnId" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="作者">
              <a-input v-model="queryParam.author" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="焦点关注">
              <a-select v-model="queryParam.isFocus" placeholder="请选择" default-value="">
                <a-select-option value="">全部</a-select-option>
                <a-select-option value="true">是</a-select-option>
                <a-select-option value="false">否</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="热门推荐">
              <a-select v-model="queryParam.isHot" placeholder="请选择" default-value="">
                <a-select-option value="">全部</a-select-option>
                <a-select-option value="true">是</a-select-option>
                <a-select-option value="false">否</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="图文特推">
              <a-select v-model="queryParam.isImg" placeholder="请选择" default-value="">
                <a-select-option value="">全部</a-select-option>
                <a-select-option value="true">是</a-select-option>
                <a-select-option value="false">否</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="封面">
              <a-input v-model="queryParam.coverId" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="是否外链">
              <a-select v-model="queryParam.isLink" placeholder="请选择" default-value="">
                <a-select-option value="">全部</a-select-option>
                <a-select-option value="true">是</a-select-option>
                <a-select-option value="false">否</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <span class="table-page-search-submitButtons" >
                <!-- :style="advanced && { float: 'right', overflow: 'hidden' } || {} " -->
              <a-button type="primary" @click="getDataList">查询</a-button>
              <a-button style="margin-left: 8px" @click="() => queryParam = {}">重置</a-button>
            </span>
          </a-col>
        </a-row>
      </a-form>
    </div>

    <div class="table-operator">
      <a-button type="primary" icon="plus" @click="$refs.editModal.add()">新建</a-button>
    </div>

    <a-table :dataSource="tableList" :pagination="pagination" @change="handleTableChange" :loading="loading" rowKey="id">
      
        <a-table-column title="栏目ID" dataIndex="columnId" />
        <a-table-column title="作者" dataIndex="author" />
          <a-table-column title="焦点关注" dataIndex="isFocus">
            <template slot-scope="isFocus">
              <span>
                <a-tag v-if="isFocus" color="blue">是</a-tag>
                <a-tag v-else color="orange">否</a-tag>
              </span>
            </template>
          </a-table-column>
          <a-table-column title="热门推荐" dataIndex="isHot">
            <template slot-scope="isHot">
              <span>
                <a-tag v-if="isHot" color="blue">是</a-tag>
                <a-tag v-else color="orange">否</a-tag>
              </span>
            </template>
          </a-table-column>
          <a-table-column title="图文特推" dataIndex="isImg">
            <template slot-scope="isImg">
              <span>
                <a-tag v-if="isImg" color="blue">是</a-tag>
                <a-tag v-else color="orange">否</a-tag>
              </span>
            </template>
          </a-table-column>
        <a-table-column title="排序" dataIndex="sort" />
        <a-table-column title="封面" dataIndex="coverId" />
        <a-table-column title="浏览量" dataIndex="hits" />
          <a-table-column title="是否外链" dataIndex="isLink">
            <template slot-scope="isLink">
              <span>
                <a-tag v-if="isLink" color="blue">是</a-tag>
                <a-tag v-else color="orange">否</a-tag>
              </span>
            </template>
          </a-table-column>
      
      <a-table-column title="操作" key="action">
      <template slot-scope="text, record">
        <span>
          <a @click="handleDetail(record.id)">详情</a>
          <a-divider type="vertical" />
          <a @click="handleEdit(record.id)">编辑</a>
          <a-divider type="vertical" />
              <a-popconfirm title="确定要删除这行数据吗?" placement="topLeft" @confirm="handleDel(record.id)">
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

    <edit-form ref="editModal" :afterSubmit="handleOk" />
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
  data () {
    return {
      tableList:[],
      // 查询参数
      queryParam: {name:"",page:1},
      pagination:{total:1,pageSize:20},
      loading : true
    }
  },
  created () {
    
  },
  mounted() {
    this.getDataList()
  },
  methods: {
    getDataList(){
      this.loading = true;
      axios.get("api/Article",{params : this.queryParam}).then(res=>{
        const {data,totalCount} = res.data;
        this.tableList = data;
        this.pagination.total = totalCount;
        this.loading = false;
      }).catch(()=>{
        this.loading = false;
      });
    },
    handleOk(){
      this.getDataList()
    },
    handleTableChange(pagination){
      this.queryParam.page= pagination.current;
      this.getDataList();
    },
    handleEdit(id) {
      this.$refs.editModal.edit(id)
    },
    handleDetail(id) {
      this.$refs.detailModal.detail(id)
    },
    handleDel(id){
        axios.delete('api/Article/' + id).then(res => {
          this.$message.info(`删除成功`);
          this.getDataList();
        })
    }
  }
}
</script>
