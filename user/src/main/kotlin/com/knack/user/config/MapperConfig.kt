package com.knack.user.config

import org.modelmapper.ModelMapper
import org.springframework.context.annotation.Bean
import org.springframework.context.annotation.Configuration

@Configuration
class MapperConfig {

    @Bean
    fun provideModelMapperBean(): ModelMapper {
        return ModelMapper()
    }
}