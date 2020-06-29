﻿using Arts.Application.DataTransfer;
using Arts.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Implementation.Profiles
{
    public class PostsCommentsProfile: Profile
    {
        public PostsCommentsProfile()
        {
            CreateMap<Comment, SingleCommentDto>();
            CreateMap<SingleCommentDto, Comment>();
        }
    }
}
