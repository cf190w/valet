project(
    'twm',
    'c',
    default_options: [
        'warning_level=3',
        'werror=true',
    ],
    version: '1.0.12',
)

add_project_arguments(
    '-DAPP_VERSION="@0@"'.format(meson.project_version()),
    language: 'c',
)

add_project_arguments(
    '-DDATA_DIR="@0@"'.format(get_option('datadir')),
    language: 'c',
)

if meson.get_compiler('c').has_function('mkstemp')
    add_project_arguments(
        '-DHAVE_MKSTEMP=1',
        language: 'c',
    )
endif

twm_dependencies = [
    dependency('x11'),
    dependency('xext'),
    dependency('xt'),
    dependency('xmu'),
    dependency('ice'),
    dependency('sm'),
    dependency('xproto', version:'>=7.0.17'),
]

xrandr = dependency('xrandr', required: false)
if xrandr.found()
    twm_dependencies += xrandr

    add_project_arguments('-DHAVE_XRANDR', language: 'c')
endif

subdir('src')
subdir('man')
