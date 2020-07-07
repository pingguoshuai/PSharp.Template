// eslint-disable-next-line
import { UserLayout, BasicLayout, RouteView, BlankLayout, PageView } from '@/layouts'
import { bxAnaalyse } from '@/core/icons'

export const asyncRouterMap = [

  {
    path: '/',
    name: 'index',
    component: BasicLayout,
    meta: { title: '首页' },
    redirect: '/dashboard/Workplace',
    children: [
      // dashboard
      {
        path: 'dashboard',
        name: 'dashboard',
        redirect: '/dashboard/Workplace',
        component: RouteView,
        meta: { title: '仪表盘', keepAlive: true, icon: 'home', permission: [ 'dashboard' ] },
        children: [
          {
            path: 'Workplace',
            name: 'Workplace',
            component: () => import('@/views/dashboard/Workplace'),
            meta: { title: '工作台', keepAlive: true, permission: [ 'dashboard' ] }
          },
        ]
      },

      // 字典
      {
        path: '/common',
        name: 'common',
        component: PageView,
        meta: { title: '基础数据', icon: 'database', permission: [ 'common' ] },
        redirect: '/common/dictionary/',
        children: [
          {
            path: '/common/dictionary',
            name: 'dictionary',
            component: RouteView,
            meta: { title: '数据字典', permission: [ 'common' ] },
            redirect: '/common/dictionary/index',
            children: [
              {
                path: '/common/dictionary/dictype',
                name: 'Dictype',
                component: () => import('@/views/common/dictype/index'),
                meta: { title: '字典类型', keepAlive: false, permission: [ 'common' ] }
              },
              {
                path: '/common/dictionary/dicinfo',
                name: 'Dicinfo',
                component: () => import('@/views/common/dicinfo/index'),
                meta: { title: '字典信息', keepAlive: false, permission: [ 'common' ] }
              }
            ]
          },
          {
            path: '/common/filemanage',
            name: 'FileForm',
            component: () => import('@/views/common/filemanage/index'),
            meta: { title: '文件管理', keepAlive: false, permission: [ 'filemanage' ] }
          }
        ]
      },
      // //会员管理
      // {
      //   path: '/member',
      //   component: PageView,
      //   name: 'membermanage',
      //   meta: { title: '会员管理', icon: bxAnaalyse, permission: [ 'common' ] },
      //   redirect: '/member/member/',
      //   children:[
      //     {
      //       path: '/member/member',
      //       name: 'member',
      //       component: () => import('@/views/consult/member/index'),
      //       meta: { title: '会员管理', keepAlive: false, permission: [ 'dashboard' ] }
      //     }
      //   ]
      // },
      //系统管理
      {
        path: '/system',
        component: PageView,
        name: 'systemmanage',
        meta: { title: '系统管理', icon: 'tool', permission: [ 'system' ] },
        children:[
          {
            path: '/system/application',
            name: 'systemapplication',
            component: () => import('@/views/systems/application/index'),
            meta: { title: '应用程序管理', keepAlive: false, permission: [ 'system' ] }
          },
          {
            path: '/system/resource',
            name: 'systemresource',
            component: () => import('@/views/systems/resource/index'),
            meta: { title: '资源管理', keepAlive: false, permission: [ 'system' ] }
          },
          {
            path: '/system/user',
            name: 'systemuser',
            component: () => import('@/views/systems/user/index'),
            meta: { title: '账户管理', keepAlive: false, permission: [ 'system' ] }
          },
          {
            path: '/system/role',
            name: 'systemrole',
            component: () => import('@/views/systems/role/index'),
            meta: { title: '角色管理', keepAlive: false, permission: [ 'system' ] }
          },
          {
            path: '/system/cache',
            name: 'systemcache',
            component: () => import('@/views/systems/cache/index'),
            meta: { title: '缓存管理', keepAlive: false, permission: [ 'system' ] }
          }
        ]
      },

      
      // account
      {
        path: '/account',
        component: RouteView,
        redirect: '/account/center',
        name: 'account',
        meta: { title: '个人页', icon: 'user', keepAlive: true, permission: [ 'user' ] },
        children: [
          {
            path: '/account/settings',
            name: 'settings',
            component: () => import('@/views/account/settings/Index'),
            meta: { title: '个人设置', hideHeader: true, permission: [ 'user' ] },
            redirect: '/account/settings/base',
            hideChildrenInMenu: true,
            children: [
              {
                path: '/account/settings/base',
                name: 'BaseSettings',
                component: () => import('@/views/account/settings/BaseSetting'),
                meta: { title: '基本设置', hidden: true, permission: [ 'user' ] }
              }
            ]
          }
        ]
      }
    ]
  },
  {
    path: '*', redirect: '/404', hidden: true
  }
]

/**
 * 基础路由
 * @type { *[] }
 */
export const constantRouterMap = [
  {
    path: '/user',
    component: UserLayout,
    redirect: '/user/login',
    hidden: true,
    children: [
      {
        path: 'login',
        name: 'login',
        component: () => import(/* webpackChunkName: "user" */ '@/views/user/Login')
      },
      {
        path: 'register',
        name: 'register',
        component: () => import(/* webpackChunkName: "user" */ '@/views/user/Register')
      },
      {
        path: 'register-result',
        name: 'registerResult',
        component: () => import(/* webpackChunkName: "user" */ '@/views/user/RegisterResult')
      },
      {
        path: 'recover',
        name: 'recover',
        component: undefined
      }
    ]
  },

  {
    path: '/test',
    component: BlankLayout,
    redirect: '/test/home',
    children: [
      {
        path: 'home',
        name: 'TestHome',
        component: () => import('@/views/Home')
      }
    ]
  },

  {
    path: '/404',
    component: () => import(/* webpackChunkName: "fail" */ '@/views/exception/404')
  }

]
