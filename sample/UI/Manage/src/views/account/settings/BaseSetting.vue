<template>
  <div class="account-settings-info-view">
    <a-spin :spinning="confirmLoading">
    <a-row :gutter="16">
      <a-col :md="24" :lg="16">
        <a-form :form="form">
          <a-form-item label="用户名">
            <a-input placeholder="请输入用户名" v-decorator="['userName', userNameCheck]" />
          </a-form-item>
          <a-form-item label="昵称">
            <a-input placeholder="请输入昵称" v-decorator="['nickName', nickNameCheck]" />
          </a-form-item>
          <a-form-item label="姓名">
            <a-input placeholder="请输入姓名" v-decorator="['name', nameCheck]" />
          </a-form-item>
          <a-form-item label="邮箱">
            <a-input placeholder="请输入邮箱" v-decorator="['email', emailCheck]" />
          </a-form-item>
          <a-form-item label="手机">
            <a-input placeholder="请输入手机" v-decorator="['phoneNumber', phoneNumberCheck]" />
          </a-form-item>
          <a-form-item label="密码">
            <a-input-password placeholder="若不需修改密码请跳过该行" v-decorator="['password', passwordCheck]" />
          </a-form-item>
          <!-- <a-form-item label="Bio">
            <a-textarea rows="4" placeholder="You are not alone." v-decorator="['name', nameCheck]" />
          </a-form-item>
          <a-form-item label="电子邮件" :required="false">
            <a-input placeholder="exp@admin.com" v-decorator="['email', emailCheck]" />
          </a-form-item>
          <a-form-item label="加密方式" :required="false">
            <a-select defaultValue="aes-256-cfb">
              <a-select-option value="aes-256-cfb">aes-256-cfb</a-select-option>
              <a-select-option value="aes-128-cfb">aes-128-cfb</a-select-option>
              <a-select-option value="chacha20">chacha20</a-select-option>
            </a-select>
          </a-form-item>
          <a-form-item label="连接密码" :required="false">
            <a-input placeholder="h3gSbecd" v-decorator="['name', nameCheck]" />
          </a-form-item>
          <a-form-item label="登录密码" :required="false">
            <a-input-password placeholder="密码" v-decorator="['password', passwordData]" />
          </a-form-item> -->

          <a-form-item>
            <a-button :loading="confirmLoading" @click="handleSubmit" type="primary">保存</a-button>
          </a-form-item>
        </a-form>
      </a-col>
      <!-- <a-col :md="24" :lg="8" :style="{ minHeight: '180px' }">
        <div class="ant-upload-preview" @click="$refs.modal.edit(1)">
          <a-icon type="cloud-upload-o" class="upload-icon" />
          <div class="mask">
            <a-icon type="plus" />
          </div>
          <img :src="option.img" />
        </div>
      </a-col> -->
    </a-row>
    </a-spin>
    <avatar-modal ref="modal" @ok="setavatar" />
  </div>
</template>

<script>
import AvatarModal from './AvatarModal'
import { axios } from '@/utils/request'

export default {
  components: {
    AvatarModal
  },
  data() {
    return {
      // cropper
      form: this.$form.createForm(this),
      confirmLoading: false,
      preview: {},
      option: {
        img: '/avatar2.jpg',
        info: true,
        size: 1,
        outputType: 'jpeg',
        canScale: false,
        autoCrop: true,
        // 只有自动截图开启 宽度高度才生效
        autoCropWidth: 180,
        autoCropHeight: 180,
        fixedBox: true,
        // 开启宽度和高度比例
        fixed: true,
        fixedNumber: [1, 1]
      },
      userNameCheck: {
        rules: [
          { max: 256, message: '不能超过256个字符' },
          { required: true, message: '请输入用户名' }
        ]
      },
      nickNameCheck: {
        rules: [
          { max: 256, message: '不能超过256个字符' },
          { required: true, message: '请输入昵称' }
        ]
      },
      nameCheck: {
        rules: [
          { max: 256, message: '不能超过256个字符' },
          { required: true, message: '请输入姓名' }
        ]
      },
      emailCheck: {
        rules: [
          { pattern: /^([a-zA-Z\d])(\w|\-)+@[a-zA-Z\d]+\.[a-zA-Z]{2,4}$/, message: '请输入正确的邮箱' },
          { max: 256, message: '不能超过256个字符' },
          { required: true, message: '请输入邮箱' }
        ]
      },
      phoneNumberCheck: {
        rules: [
          { pattern: /^[1][3,4,5,7,8][0-9]{9}$/, message: '请输入正确的手机号' },
          { required: true, message: '请输入手机' }
        ]
      },
      passwordCheck: { rules: [{ max: 16, message: '不能超过16个字符' }] },
      enabledCheck: { valuePropName: 'checked', initialValue: true }
    }
  },
  created() {
    this.getUserInfo()
  },
  methods: {
    setavatar(url) {
      this.option.img = url
    },
    getUserInfo() {
      let id = this.$store.state.user.info.id
      this.$nextTick(() => {
        this.form.resetFields()
        var formFields = this.form.getFieldsValue()
        this.confirmLoading = true
        axios.get('User/' + id).then(res => {
          this.entity = res.data
          var setData = {}
          Object.keys(formFields).forEach(item => {
            setData[item] = this.entity[item]
          })
          this.form.setFieldsValue(setData)
          this.confirmLoading = false
        })
      })
    },
    handleSubmit() {
      this.form.validateFields((errors, values) => {
        if (!errors) {
          let entity = Object.assign(this.entity, this.form.getFieldsValue())
          this.confirmLoading = true
            axios
              .put('User', entity)
              .then(res => {
                this.visible = false
                this.confirmLoading = false
                this.getUserInfo()
              })
              .catch(errors => {
                this.confirmLoading = false
              })
        }
      })
    },
  }
}
</script>

<style lang="less" scoped>
.avatar-upload-wrapper {
  height: 200px;
  width: 100%;
}

.ant-upload-preview {
  position: relative;
  margin: 0 auto;
  width: 100%;
  max-width: 180px;
  border-radius: 50%;
  box-shadow: 0 0 4px #ccc;

  .upload-icon {
    position: absolute;
    top: 0;
    right: 10px;
    font-size: 1.4rem;
    padding: 0.5rem;
    background: rgba(222, 221, 221, 0.7);
    border-radius: 50%;
    border: 1px solid rgba(0, 0, 0, 0.2);
  }
  .mask {
    opacity: 0;
    position: absolute;
    background: rgba(0, 0, 0, 0.4);
    cursor: pointer;
    transition: opacity 0.4s;

    &:hover {
      opacity: 1;
    }

    i {
      font-size: 2rem;
      position: absolute;
      top: 50%;
      left: 50%;
      margin-left: -1rem;
      margin-top: -1rem;
      color: #d6d6d6;
    }
  }

  img,
  .mask {
    width: 100%;
    max-width: 180px;
    height: 100%;
    border-radius: 50%;
    overflow: hidden;
  }
}
</style>
