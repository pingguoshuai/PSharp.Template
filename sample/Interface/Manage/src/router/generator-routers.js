// eslint-disable-next-line
import * as loginService from '@/api/login'
// eslint-disable-next-line
import { BasicLayout, BlankLayout, PageView, RouteView } from '@/layouts'
import { bxAnaalyse } from '@/core/icons'

// 前端路由表
const constantRouterComponents = {
  // 基础页面 layout 必须引入
  BasicLayout: BasicLayout,
  BlankLayout: BlankLayout,
  RouteView: RouteView,
  PageView: PageView,
  '403': () => import(/* webpackChunkName: "error" */ '@/views/exception/403'),
  '404': () => import(/* webpackChunkName: "error" */ '@/views/exception/404'),
  '500': () => import(/* webpackChunkName: "error" */ '@/views/exception/500'),

  // 你需要动态引入的页面组件
  'Workplace': () => import('@/views/dashboard/Workplace'),

  // result
  'ResultSuccess': () => import(/* webpackChunkName: "result" */ '@/views/result/Success'),
  'ResultFail': () => import(/* webpackChunkName: "result" */ '@/views/result/Error'),

  // exception
  'Exception403': () => import(/* webpackChunkName: "fail" */ '@/views/exception/403'),
  'Exception404': () => import(/* webpackChunkName: "fail" */ '@/views/exception/404'),
  'Exception500': () => import(/* webpackChunkName: "fail" */ '@/views/exception/500'),

  // account
  'AccountSettings': () => import('@/views/account/settings/Index'),
  'BaseSettings': () => import('@/views/account/settings/BaseSetting')
}

// 前端未找到页面路由（固定不用改）
const notFoundRouter = {
  path: '*', redirect: '/404', hidden: true
}

// 根级菜单
const rootRouter = {
  key: '',
  name: 'index',
  path: '/',
  component: BasicLayout,
  redirect: '/cell/sample/index',
  meta: {
    title: '首页'
  },
  children: [{
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
      }
    ]
  }]
}

const acctountRouter = {
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

/**
 * 动态生成菜单
 * @param menus
 * @returns {Promise<Router>}
 */
export const generatorDynamicRouter = (menus) => {
  return new Promise((resolve, reject) => {
      const menuNav = []
      const childrenNav = []
      //      后端数据, 根级树数组,  根级 PID
      listToTree(menus, childrenNav, null)
      
      rootRouter.children =rootRouter.children.concat( generator(childrenNav))
      rootRouter.children.push(acctountRouter)
      menuNav.push(rootRouter)
      menuNav.push(notFoundRouter)
      resolve(menuNav)
  })
}

/**
 * 格式化树形结构数据 生成 vue-router 层级路由表
 *
 * @param routerMap
 * @param parent
 * @returns {*}
 */
export const generator = (routerMap, parent) => {
  return routerMap.map(item => {
    const { title, isHide, hideChildren, icon, keepAlive } = item || {}
    const currentRouter = {
      // 如果路由设置了 path，则作为默认 path，否则 路由地址 动态拼接生成如 /dashboard/workplace
      path: item.routeUri || `${parent && parent.routeUri || ''}/${item.key}`,
      // 路由名称，建议唯一
      name: item.routeName,
      // 该路由对应页面的 组件 :方案1
      // component: constantRouterComponents[item.component || item.key],
      // 该路由对应页面的 组件 :方案2 (动态加载)
      // component: (constantRouterComponents[item.component || item.key]) || (() => import(`@/views/${item.routeUri}`)),

      // meta: 页面标题, 菜单图标, 页面权限(供指令权限用，可去掉)
      meta: {
        title: title,
        icon: icon || bxAnaalyse,
        keepAlive: keepAlive
        // hiddenHeaderContent: hiddenHeaderContent,
        // target: target,
        // permission: item.name
      }
    }
    if(item.level!=1) currentRouter.meta.icon = undefined
    // 是否设置了隐藏菜单
    if (isHide === true) {
      currentRouter.hidden = true
    }
    // 是否设置了隐藏子菜单
    if (hideChildren) {
      currentRouter.hideChildrenInMenu = true
    }
    // 为了防止出现后端返回结果不规范，处理有可能出现拼接出两个 反斜杠
    if (!currentRouter.path.startsWith('http')) {
      currentRouter.path = currentRouter.path.replace('//', '/')
    }
    // 重定向
    item.redirect && (currentRouter.redirect = item.redirect)
    // 是否有子菜单，并递归处理
    let component = {}
    if (item.children && item.children.length > 0) {
      // Recursion
      currentRouter.children = generator(item.children, currentRouter)
      component = item.level == 1 ? PageView : RouteView
    }else
    {
      component = () => import(`@/views${item.routeUri}`)
    }
    currentRouter.component = component
    return currentRouter
  })
}

/**
 * 数组转树形结构
 * @param list 源数组
 * @param tree 树
 * @param parentId 父ID
 */
const listToTree = (list, tree, parentId) => {
  list.forEach(item => {
    // 判断是否为父级菜单
    if (item.parentId === parentId) {
      const child = {
        ...item,
        key: item.key || item.name,
        children: []
      }
      // 迭代 list， 找到当前菜单相符合的所有子菜单
      listToTree(list, child.children, item.id)
      // 删掉不存在 children 值的属性
      if (child.children.length <= 0) {
        delete child.children
      }
      // 加入到树中
      tree.push(child)
    }
  })
}
