
<template>
  <a-modal
    title="权限"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    :footer="null"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-radio-group size="large" v-model="titleValue" @change="radioChange" style="margin-bottom:20px">
        <a-radio-button v-for="item of titleList" :key="item.key" :value="item.key">
          {{ item.name }}
        </a-radio-button>
      </a-radio-group>
      <a-row v-if="titleValue == 'page'">
        <a-spin :spinning="loading">
          <a-col :span="4">
            <a-menu
              v-if="applicationList && queryParam.applicationId"
              mode="inline"
              :defaultSelectedKeys="[queryParam.applicationId]"
              @select="selectMenu"
            >
              <a-menu-item v-for="item of applicationList" :key="item.id">
                {{ item.name }}
              </a-menu-item>
            </a-menu>
          </a-col>
          <a-col :span="20">
            <a-tree
              v-if="resourceList && resourceList.length > 0"
              :checkedKeys="powerList"
              :checkable="true"
              :defaultExpandAll="true"
              :tree-data="resourceList"
              :checkStrictly="true"
              @check="onCheck"
            />
            <a-empty v-else />
          </a-col>
          <a-divider />
          <a-col :offset="20">
            <a-button type="primary" @click="handleSubmit">保存</a-button>
          </a-col>
        </a-spin>
      </a-row>

      <a-select
        v-if="applicationList && applicationList.length > 0 && titleValue == 'api'"
        :default-value="queryParam.applicationId"
        style="width:50%;margin-left:20px"
        @select="changeSelect"
      >
        <a-select-option v-for="item of applicationList" :key="item.id">
          {{ item.name }}
        </a-select-option>
      </a-select>
      <a-row v-if="titleValue == 'api'">
        <a-spin :spinning="loading">
          <a-tree
            class="tree"
            v-if="interfaceList && interfaceList.length > 0"
            :checkedKeys="powerList"
            :checkable="true"
            :defaultExpandAll="true"
            :tree-data="interfaceList"
            :checkStrictly="true"
            :replaceFields="replaceFields"
            @check="onCheck"
          />
          <a-divider />
          <a-col :offset="20">
            <a-button type="primary" @click="handleSubmit">保存</a-button>
          </a-col>
        </a-spin>
      </a-row>
    </a-spin>
  </a-modal>
</template>

<script>
import { axios } from '@/utils/request'
import pick from 'lodash.pick'

export default {
  props: {
    afterSubmit: {
      type: Function,
      default: null
    }
  },
  data() {
    return {
      labelCol: { xs: { span: 24 }, sm: { span: 7 } },
      wrapperCol: { xs: { span: 24 }, sm: { span: 13 } },
      visible: false,
      loading: false,
      confirmLoading: false,
      roleId: '',
      powerList: [],
      resourceList: [],
      interfaceList: [],
      applicationList: [],
      titleList: [
        { name: '页面', key: 'page' },
        { name: '接口', key: 'api' }
      ],
      titleValue: '',
      queryParam: {},
      replaceFields: {
        children: 'children',
        title: 'name',
        key: 'code'
      }
    }
  },
  methods: {
    // 页面起始调起方法
    power(id) {
      this.visible = true
      this.confirmLoading = true
      this.roleId = id
      this.titleValue = 'page'
      this.getDataList()
    },
    // 获取数据
    getDataList() {
      console.log(1)
      this.powerList = []
      this.resourceList = []
      this.interfaceList = []
      this.applicationList = []
      this.queryParam = {}
      if (this.titleValue == 'page') {
        this.getApplicationList()
      } else {
        this.getInterfaceList()
      }
    },
    // 获取用户当前权限
    getPermissionList() {
      axios
        .get('Permission/ResourceIds?ApplicationId=' + this.queryParam.applicationId + '&RoleId=' + this.roleId)
        .then(res => {
          this.powerList = res.data
          this.loading = false
        })
        .catch(errors => {
          this.loading = false
        })
    },
    // 获取当前目录的权限
    getResourceList() {
      axios.get('Resource?ApplicationId=' + this.queryParam.applicationId).then(res => {
        this.resourceList = res.data
        this.getPermissionList()
      })
    },
    // 获取资源目录
    getApplicationList() {
      axios.get('Application/All').then(res => {
        this.queryParam.applicationId = res.data[0].id
        this.applicationList = res.data
        this.loading = true
        this.confirmLoading = false
        this.getResourceList()
      })
    },
    // 获取角色当前api接口权限
    getInterfaceCodesList() {
      axios
        .get('Permission/InterfaceCodes?ApplicationId=' + this.queryParam.applicationId + '&RoleId=' + this.roleId)
        .then(res => {
          this.powerList = res.data
          this.loading = false
        })
        .catch(errors => {
          this.loading = false
        })
    },
    // 获取所有接口
    getInterfaceList() {
      axios.get('Application/All').then(res => {
        this.queryParam.applicationId = res.data[0].id
        this.applicationList = res.data
      })
      axios.get('Interface/All').then(res => {
        this.interfaceList = res.data
        this.loading = true
        this.confirmLoading = false
        this.getInterfaceCodesList()
      })
    },
    // 点击tree
    onCheck(checkedKeys) {
      this.powerList = checkedKeys.checked
    },
    // 切换菜单
    selectMenu(res) {
      this.loading = true
      this.queryParam.applicationId = res.key
      this.getResourceList()
    },
    // 切换菜单
    changeSelect(res) {
      this.loading = true
      this.queryParam.applicationId = res
      this.getInterfaceCodesList()
    },
    // 切换页面
    radioChange(res) {
      this.loading = true
      this.getDataList()
    },
    handleSubmit() {
      console.log(this.powerList)
      if (!!this.powerList && this.powerList.length == 0) {
        this.$message.info(`请选择权限`)
        return
      }
      let data = {
        applicationId: this.queryParam.applicationId,
        roleId: this.roleId,
        resourceIds: this.powerList.join(','),
        interfaceCodes: this.powerList.join(',')
      }
      this.confirmLoading = true
      if (this.titleValue == 'page') {
        // data.resourceIds = this.powerList.join(',')
        axios
          .post('Permission', data)
          .then(res => {
            this.visible = false
            this.confirmLoading = false
            this.afterSubmit()
          })
          .catch(errors => {
            this.confirmLoading = false
          })
      } else {
        // data.interfaceCodes = this.powerList.join(',')
        axios
          .post('Permission/SaveInterface', data)
          .then(res => {
            this.visible = false
            this.confirmLoading = false
            this.afterSubmit()
          })
          .catch(errors => {
            this.confirmLoading = false
          })
      }
    },
    handleCancel() {
      this.visible = false
    }
  }
}
</script>

<style>
.tree > li > .ant-tree-checkbox {
  display: none;
}
.ant-tree-child-tree {
  display: flex;
  flex-wrap: wrap;
  align-items: flex-start;
}
.ant-tree-child-tree > li:first-child {
  padding-top: 4px;
}
</style>