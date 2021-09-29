module.exports = {
  mode: 'jit',
    purge: ["Views/**/*.cshtml", "Views/**/*.razor"],
  darkMode: false, // or 'media' or 'class'
  theme: {
      extend: {}
  },
  variants: {
    extend: {},
  },
    plugins: [
        require('@tailwindcss/forms'),
        require('@tailwindcss/typography')
    ],
}