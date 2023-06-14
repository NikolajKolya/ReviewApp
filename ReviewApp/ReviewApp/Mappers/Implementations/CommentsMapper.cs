﻿using goods.DAO.Models;
using goods.Mappers.Abstract;
using ReviewApp.Models.Dto;

namespace goods.Mappers.Implementations;

public class CommentsMapper : ICommentsMapper
{
    public IReadOnlyCollection<CommentDto> Map(IEnumerable<Comment> comments)
    {
        if (comments == null)
        {
            return null;
        }

        return comments.Select(n => Map(n)).ToList();
    }

    public CommentDto Map(Comment comment)
    {
        return new CommentDto()
        {
            Id = comment.Id,
            Content = comment.Content,
            Rating = comment.Rating
        };
    }

    public Comment Map(CommentDto comment)
    {
        return new Comment()
        {
            Id = comment.Id,
            Good = null, // Нужно заполнить извне, после маппинга
            Content = comment.Content,
            Rating = comment.Rating
        };
    }

    public IReadOnlyCollection<Comment> Map(IEnumerable<CommentDto> comments)
    {
        if (comments == null)
        {
            return null;
        }

        return comments.Select(n => Map(n)).ToList();
    }
}