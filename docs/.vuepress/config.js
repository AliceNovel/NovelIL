import { defaultTheme } from '@vuepress/theme-default'
import { defineUserConfig } from 'vuepress'
import { viteBundler } from '@vuepress/bundler-vite'

export default defineUserConfig({
  locales: {
    // The key is the path for the locale to be nested under.
    // As a special case, the default locale can use '/' as its path.
    '/': {
      lang: 'en-US',

      title: 'Novel IL',
      description: 'The Novel IL Specification',
    },
    '/ja/': {
      lang: 'ja-JP',

      title: 'Novel IL',
      description: 'Novel IL の公式仕様',
    },
  },
  theme: defaultTheme({
    logo: 'https://vuejs.press/images/hero.png',

    navbar: ['/ja/', '/ja/get-started'],
  }),

  bundler: viteBundler(),
})
