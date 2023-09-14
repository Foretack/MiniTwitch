using MiniTwitch.PubSub.Internal.Enums;
using MiniTwitch.PubSub.Payloads;

namespace MiniTwitch.PubSub.Test;

public static class Payloads
{
    [Topic("channel-points-channel-v1.27620241", MessageTopic.ChannelPoints, typeof(ChannelPoints))]
    public const string RewardRedeemedJson = """
    {
        "type": "reward-redeemed",
        "data": {
            "timestamp": "2020-10-10T19:13:30.536153182Z",
            "redemption": {
                "id": "b021f290-bedb-49c2-b90f-e6ceb1c0d4ab",
                "user": {
                    "id": "27620241",
                    "login": "emilgardis",
                    "display_name": "emilgardis"
                },
                "channel_id": "27620241",
                "redeemed_at": "2020-10-10T19:13:30.536153182Z",
                "reward": {
                    "id": "252e209d-4f16-4886-a0d1-97f458ad5698",
                    "channel_id": "27620241",
                    "title": "Hydration",
                    "prompt": "Make Emilgardis drink water",
                    "cost": 2000,
                    "is_user_input_required": true,
                    "is_sub_only": false,
                    "image": null,
                    "default_image": {
                        "url_1x": "https://static-cdn.jtvnw.net/custom-reward-images/default-1.png",
                        "url_2x": "https://static-cdn.jtvnw.net/custom-reward-images/default-2.png",
                        "url_4x": "https://static-cdn.jtvnw.net/custom-reward-images/default-4.png"
                    },
                    "background_color": "#81AEFF",
                    "is_enabled": true,
                    "is_paused": false,
                    "is_in_stock": true,
                    "max_per_stream": {
                        "is_enabled": false,
                        "max_per_stream": 10
                    },
                    "should_redemptions_skip_request_queue": false,
                    "template_id": null,
                    "updated_for_indicator_at": "2020-02-06T17:29:19.737311439Z",
                    "max_per_user_per_stream": {
                        "is_enabled": false,
                        "max_per_user_per_stream": 0
                    },
                    "global_cooldown": {
                        "is_enabled": false,
                        "global_cooldown_seconds": 0
                    },
                    "redemptions_redeemed_current_stream": 0,
                    "cooldown_expires_at": null
                },
                "user_input": "bap",
                "status": "UNFULFILLED"
            }
        }
    }
    """;

    [Topic("channel-points-channel-v1.27620241", MessageTopic.ChannelPoints, typeof(ChannelPoints))]
    public const string CustomRewardUpdatedJson = """
        {
            "type": "custom-reward-updated",
            "data": {
                "timestamp": "2020-10-19T19:40:19.637568468Z",
                "updated_reward": {
                    "id": "071397fb-cd09-420d-8d64-f9fd35f5cdfa",
                    "channel_id": "27620241",
                    "title": "Up the difficulty ",
                    "prompt": "stuff.",
                    "cost": 20000,
                    "is_user_input_required": true,
                    "is_sub_only": false,
                    "image": null,
                    "default_image": {
                        "url_1x": "https://static-cdn.jtvnw.net/custom-reward-images/default-1.png",
                        "url_2x": "https://static-cdn.jtvnw.net/custom-reward-images/default-2.png",
                        "url_4x": "https://static-cdn.jtvnw.net/custom-reward-images/default-4.png"
                    },
                    "background_color": "#FF6C00",
                    "is_enabled": true,
                    "is_paused": true,
                    "is_in_stock": true,
                    "max_per_stream": {
                        "is_enabled": true,
                        "max_per_stream": 6
                    },
                    "should_redemptions_skip_request_queue": false,
                    "template_id": null,
                    "updated_for_indicator_at": "2020-06-09T16:02:06.943429808Z",
                    "max_per_user_per_stream": {
                        "is_enabled": false,
                        "max_per_user_per_stream": 0
                    },
                    "global_cooldown": {
                        "is_enabled": false,
                        "global_cooldown_seconds": 0
                    },
                    "redemptions_redeemed_current_stream": 0,
                    "cooldown_expires_at": null
                }
            }
        }
        """;

    [Topic("channel-subscribe-events-v1.27620241", MessageTopic.SubscribeEvents, typeof(SubscribeEvents))]
    public const string ResubJson = """
        {
            "benefit_end_month": 0,
            "user_name": "tmi",
            "display_name": "tmi",
            "channel_name": "emilgardis",
            "user_id": "1234",
            "channel_id": "80525799",
            "time": "2020-10-25T17:15:36.541972298Z",
            "sub_message": {
                "message": "message here",
                "emotes": [
                    {
                        "start": 191,
                        "end": 197,
                        "id": "12342378"
                    }
                ]
            },
            "sub_plan": "2000",
            "sub_plan_name": "Channel Subscription (emilgardis): $9.99 Sub",
            "months": 0,
            "cumulative_months": 12,
            "streak_months": 12,
            "context": "resub",
            "is_gift": false,
            "multi_month_duration": 0
        }
        """;

    [Topic("channel-subscribe-events-v1.27620241", MessageTopic.SubscribeEvents, typeof(SubscribeEvents))]
    public const string NewSubJson = """
        {
            "benefit_end_month": 11,
            "user_name": "tmi",
            "display_name": "tmi",
            "channel_name": "emilgardis",
            "user_id": "1234",
            "channel_id": "27620241",
            "time": "2020-10-20T22:17:43.242793831Z",
            "sub_message": {
                "message": "",
                "emotes": null
            },
            "sub_plan": "1000",
            "sub_plan_name": "Channel Subscription (emilgardis)",
            "months": 0,
            "cumulative_months": 1,
            "context": "sub",
            "is_gift": false,
            "multi_month_duration": 0
        }
        """;

    [Topic("channel-subscribe-events-v1.27620241", MessageTopic.SubscribeEvents, typeof(SubscribeEvents))]
    public const string ResubGiftJson = """
        {
            "benefit_end_month": 0,
            "user_name": "emilgardis",
            "display_name": "emilgardis",
            "channel_name": "sessis",
            "user_id": "158640756",
            "channel_id": "80525799",
            "recipient_user_name": "champi70",
            "recipient_display_name": "Champi70",
            "time": "2020-12-06T18:54:52.804481633Z",
            "sub_message": {
                "message": "¡Gracias, @emilgardis, por regalarme una suscripción! thank you so mych sessis for the streams you brighten my day each time you are in stream you are awesome sessHug",
                "emotes": [
                    {
                        "start": 161,
                        "end": 167,
                        "id": "300741652"
                    }
                ]
            },
            "sub_plan": "1000",
            "sub_plan_name": "Channel Subscription (sessis)",
            "months": 0,
            "cumulative_months": 24,
            "context": "resubgift",
            "is_gift": true,
            "multi_month_duration": 0
        }
        """;

    [Topic("community-points-channel-v1.27620241", MessageTopic.CommunityChannelPoints, typeof(ChannelPoints))]
    public const string CommunityPointsJson = """
        {
            "type": "reward-redeemed",
            "data": {
                "timestamp": "2020-10-10T19:13:30.536153182Z",
                "redemption": {
                    "id": "b021f290-bedb-49c2-b90f-e6ceb1c0d4ab",
                    "user": {
                        "id": "27620241",
                        "login": "emilgardis",
                        "display_name": "emilgardis"
                    },
                    "channel_id": "27620241",
                    "redeemed_at": "2020-10-10T19:13:30.536153182Z",
                    "reward": {
                        "id": "252e209d-4f16-4886-a0d1-97f458ad5698",
                        "channel_id": "27620241",
                        "title": "Hydration",
                        "prompt": "Make Emilgardis drink water",
                        "cost": 2000,
                        "is_user_input_required": true,
                        "is_sub_only": false,
                        "image": null,
                        "default_image": {
                            "url_1x": "https://static-cdn.jtvnw.net/custom-reward-images/default-1.png",
                            "url_2x": "https://static-cdn.jtvnw.net/custom-reward-images/default-2.png",
                            "url_4x": "https://static-cdn.jtvnw.net/custom-reward-images/default-4.png"
                        },
                        "background_color": "#81AEFF",
                        "is_enabled": true,
                        "is_paused": false,
                        "is_in_stock": true,
                        "max_per_stream": {
                            "is_enabled": false,
                            "max_per_stream": 10
                        },
                        "should_redemptions_skip_request_queue": false,
                        "template_id": null,
                        "updated_for_indicator_at": "2020-02-06T17:29:19.737311439Z",
                        "max_per_user_per_stream": {
                            "is_enabled": false,
                            "max_per_user_per_stream": 0
                        },
                        "global_cooldown": {
                            "is_enabled": false,
                            "global_cooldown_seconds": 0
                        },
                        "redemptions_redeemed_current_stream": 0,
                        "cooldown_expires_at": null
                    },
                    "user_input": "bap",
                    "status": "UNFULFILLED"
                }
            }
        }
        """;

    [Topic("chat_moderator_actions.27620241.27620241", MessageTopic.ModeratorActions, typeof(ModeratorActions))]
    public const string ModActionDeleteJson = """
        {
            "type":"moderation_action",
            "data":{
                "type":"chat_login_moderation",
                "moderation_action":"delete",
                "args":[
                    "tmo",
                    "bop",
                    "e513c02d-dca5-4480-9af5-e6078d954e42"
                ],
                "created_by":"emilgardis",
                "created_by_user_id":"27620241",
                "msg_id":"",
                "target_user_id":"1234",
                "target_user_login":"",
                "from_automod":false
            }
        }
        """;

    [Topic("chat_moderator_actions.27620241.27620241", MessageTopic.ModeratorActions, typeof(ModeratorActions))]
    public const string ModActionTimeoutJson = """
        {
            "type":"moderation_action",
            "data":{
                "type":"chat_login_moderation",
                "moderation_action":"timeout",
                "args":[
                    "tmo",
                    "1",
                    ""
                ],
                "created_by":"emilgardis",
                "created_by_user_id":"27620241",
                "msg_id":"",
                "target_user_id":"1234",
                "target_user_login":"",
                "from_automod":false
            }
        }
        """;

    [Topic("chat_moderator_actions.27620241.27620241", MessageTopic.ModeratorActions, typeof(ModeratorActions))]
    public const string ModeratorAddedJson = """
        {
        	"type":"moderator_added",
        	"data":{
        		"channel_id":"27620241",
        		"target_user_id":"19264788",
        		"moderation_action":"mod",
        		"target_user_login":"nightbot",
        		"created_by_user_id":"27620241",
        		"created_by":"emilgardis"
        	}
        }
        """;

    [Topic("chat_moderator_actions.27620241.27620241", MessageTopic.ModeratorActions, typeof(ModeratorActions))]
    public const string ModeratorRemoveJson = """
        {
            "type":"moderator_removed",
            "data":{
                "channel_id":"129546453",
                "target_user_id":"691109305",
                "moderation_action":"unmod",
                "target_user_login":"rewardmore",
                "created_by_user_id":"129546453",
                "created_by":"nerixyz"
            }
        }
        """;

    [Topic("chat_moderator_actions.27620241.27620241", MessageTopic.ModeratorActions, typeof(ModeratorActions))]
    public const string ModeratorDenyUnbanRequestJson = """
        {
            "type":"deny_unban_request",
            "data":{
                "moderation_action":"DENY_UNBAN_REQUEST",
                "created_by_id":"27620241",
                "created_by_login":"emilgardis",
                "moderator_message":"ok",
                "target_user_id":"465894629",
                "target_user_login":"emil_the_impostor"
            }
        }
        """;

    [Topic("chat_moderator_actions.27620241.27620241", MessageTopic.ModeratorActions, typeof(ModeratorActions))]
    public const string ModeratorApproveUnbanRequestJson = """
        {
            "type":"approve_unban_request",
            "data":{
                "moderation_action":"APPROVE_UNBAN_REQUEST",
                "created_by_id":"27620241",
                "created_by_login":"emilgardis",
                "moderator_message":"ok",
                "target_user_id":"465894629",
                "target_user_login":"emil_the_impostor"
            }
        }
        """;

    [Topic("chat_moderator_actions.27620241.27620241", MessageTopic.ModeratorActions, typeof(ModeratorActions))]
    public const string ModerationAutomodPropertiesJson = """
        {
            "type":"moderation_action",
            "data":{
                "type":"chat_channel_moderation",
                "moderation_action":"modified_automod_properties",
                "args":null,
                "created_by":"emilgardis",
                "created_by_user_id":"27620241",
                "msg_id":"",
                "target_user_id":"",
                "target_user_login":"",
                "from_automod":false
            }
        }
        """;

    [Topic("chat_moderator_actions.27620241.27620241", MessageTopic.ModeratorActions, typeof(ModeratorActions))]
    public const string ModerationDeleteBlockedTermJson = """
        {
            "type":"channel_terms_action",
            "data":{
                "type":"delete_blocked_term",
                "id":"41a8f582-4c60-4ca1-aa10-91ec06161118",
                "text":"Hype",
                "requester_id":"27620241",
                "requester_login":"emilgardis",
                "channel_id":"27620241",
                "expires_at":"",
                "updated_at":"2021-05-10T21:35:28.745222679Z",
                "from_automod":false
            }
        }
        """;

    [Topic("user-moderation-notifications.27620241.268131879", MessageTopic.ModerationNotifications, typeof(ModerationNotificationMessage))]
    public const string ModeratorNotificationAutoModCaughtJson = """
        {
            "type":"automod_caught_message",
            "data":{
                "message_id":"d6f608f8-8f34-4f65-947c-0a92e31b0bfc",
                "status":"PENDING"
            }
        }
        """;

    [Topic("following.12345678", MessageTopic.Following, typeof(Follower))]
    public const string FollowerJson = """
        {
            "display_name": "tmi",
            "username": "tmi",
            "user_id": "1234"
        }
        """;

    [Topic("community-moments-channel-v1.169185650", MessageTopic.CommunityMoments, typeof(CommunityMoments))]
    public const string CommunityMomentsJson = """
        {
          "type": "active",
          "data": {
            "moment_id": "d069975c-17a6-4aeb-9fb0-b82ce378571e",
            "channel_id": "169185650",
            "clip_slug": "AssiduousNurturingSoymilkTheTarFu-PCf2Hb6_4CItPS0R"
          }
        }
        """;

    [Topic("video-playback-by-id.1234567", MessageTopic.VideoPlayback, typeof(VideoPlayback))]
    public const string StreamOnlinePlaybackJson = """
        {
          "server_time": 1637067607,
          "play_delay": 0,
          "type": "stream-up"
        }
        """;

    [Topic("video-playback-by-id.1234567", MessageTopic.VideoPlayback, typeof(VideoPlayback))]
    public const string ViewerCountUpdateJson = """
        {
          "type": "viewcount",
          "server_time": 1605026941.187422,
          "viewers": 5
        }
        """;

    [Topic("video-playback-by-id.1234567", MessageTopic.VideoPlayback, typeof(VideoPlayback))]
    public const string CommercialJson = """
        {
          "type": "commercial",
          "server_time": 1605026941.187422,
          "length": 30,
          "scheduled": false
        }
        """;

    [Topic("video-playback-by-id.1234567", MessageTopic.VideoPlayback, typeof(VideoPlayback))]
    public const string StreamOfflinePlaybackJson = """
        {
          "type": "commercial",
          "server_time": 1605026941.187422,
          "length": 30,
          "scheduled": false
        }
        """;

    [Topic("video-playback-by-id.1234567", MessageTopic.VideoPlayback, typeof(VideoPlayback))]
    public const string TosStrikePlaybackJson = """
        {
          "type": "tos-strike",
          "server_time": 1605281499.16761
        }
        """;

    [Topic("polls.1234567", MessageTopic.Polls, typeof(Polls))]
    public const string PollStartJson = """
                {
          "type": "POLL_CREATE",
          "data": {
            "poll": {
              "poll_id": "3315d0af-5ecd-42b4-9bc1-ab0e1bc5899d",
              "owned_by": "11148817",
              "created_by": "117691339",
              "title": "FeelsDankMan",
              "started_at": "2021-11-19T00:00:00.000000000Z",
              "ended_at": null,
              "ended_by": null,
              "duration_seconds": 120,
              "settings": {
                "multi_choice": {
                  "is_enabled": true
                },
                "subscriber_only": {
                  "is_enabled": false
                },
                "subscriber_multiplier": {
                  "is_enabled": false
                },
                "bits_votes": {
                  "is_enabled": false,
                  "cost": 0
                },
                "channel_points_votes": {
                  "is_enabled": false,
                  "cost": 0
                }
              },
              "status": "ACTIVE",
              "choices": [
                {
                  "choice_id": "00257d00-2654-4f64-9f96-c1b4c44c2a53",
                  "title": "sample text",
                  "votes": {
                    "total": 0,
                    "bits": 0,
                    "channel_points": 0,
                    "base": 0
                  },
                  "tokens": {
                    "bits": 0,
                    "channel_points": 0
                  },
                  "total_voters": 0
                }
              ],
              "votes": {
                "total": 0,
                "bits": 0,
                "channel_points": 0,
                "base": 0
              },
              "tokens": {
                "bits": 0,
                "channel_points": 0
              },
              "total_voters": 0,
              "remaining_duration_milliseconds": 119981,
              "top_contributor": null,
              "top_bits_contributor": null,
              "top_channel_points_contributor": null
            }
          }
        }
        """;

    [Topic("polls.1234567", MessageTopic.Polls, typeof(Polls))]
    public const string PollUpdateJson = """
        {
          "type": "POLL_UPDATE",
          "data": {
            "poll": {
              "poll_id": "3315d0af-5ecd-42b4-9bc1-ab0e1bc5899d",
              "owned_by": "11148817",
              "created_by": "117691339",
              "title": "FeelsDankMan",
              "started_at": "2021-11-19T00:00:00.000000000Z",
              "ended_at": null,
              "ended_by": null,
              "duration_seconds": 120,
              "settings": {
                "multi_choice": {
                  "is_enabled": true
                },
                "subscriber_only": {
                  "is_enabled": false
                },
                "subscriber_multiplier": {
                  "is_enabled": false
                },
                "bits_votes": {
                  "is_enabled": false,
                  "cost": 0
                },
                "channel_points_votes": {
                  "is_enabled": false,
                  "cost": 0
                }
              },
              "status": "ACTIVE",
              "choices": [
                {
                  "choice_id": "00257d00-2654-4f64-9f96-c1b4c44c2a53",
                  "title": "sample text",
                  "votes": {
                    "total": 0,
                    "bits": 0,
                    "channel_points": 0,
                    "base": 0
                  },
                  "tokens": {
                    "bits": 0,
                    "channel_points": 0
                  },
                  "total_voters": 0
                },
                {
                  "choice_id": "f6044b0a-fe80-46c6-8879-6f05fe5bdfcb",
                  "title": "zneixApu",
                  "votes": {
                    "total": 1,
                    "bits": 0,
                    "channel_points": 0,
                    "base": 1
                  },
                  "tokens": {
                    "bits": 0,
                    "channel_points": 0
                  },
                  "total_voters": 1
                },
                {
                  "choice_id": "c4e51b2c-7c7b-4e85-833d-2fbb7ef19089",
                  "title": "zneixFlower",
                  "votes": {
                    "total": 0,
                    "bits": 0,
                    "channel_points": 0,
                    "base": 0
                  },
                  "tokens": {
                    "bits": 0,
                    "channel_points": 0
                  },
                  "total_voters": 0
                },
                {
                  "choice_id": "b6f7c865-94d7-4ff2-8338-526146bd62e9",
                  "title": "pajaDank",
                  "votes": {
                    "total": 0,
                    "bits": 0,
                    "channel_points": 0,
                    "base": 0
                  },
                  "tokens": {
                    "bits": 0,
                    "channel_points": 0
                  },
                  "total_voters": 0
                },
                {
                  "choice_id": "5bf80362-4c0f-4052-ad6c-6d4b61ed2cd5",
                  "title": "pajaM",
                  "votes": {
                    "total": 0,
                    "bits": 0,
                    "channel_points": 0,
                    "base": 0
                  },
                  "tokens": {
                    "bits": 0,
                    "channel_points": 0
                  },
                  "total_voters": 0
                }
              ],
              "votes": {
                "total": 1,
                "bits": 0,
                "channel_points": 0,
                "base": 1
              },
              "tokens": {
                "bits": 0,
                "channel_points": 0
              },
              "total_voters": 1,
              "remaining_duration_milliseconds": 102837,
              "top_contributor": null,
              "top_bits_contributor": null,
              "top_channel_points_contributor": null
            }
          }
        }
        """;

    [Topic("polls.1234567", MessageTopic.Polls, typeof(Polls))]
    public const string PollCompleteJson = """
        {
          "type": "POLL_COMPLETE",
          "data": {
            "poll": {
              "poll_id": "3315d0af-5ecd-42b4-9bc1-ab0e1bc5899d",
              "owned_by": "11148817",
              "created_by": "117691339",
              "title": "FeelsDankMan",
              "started_at": "2021-11-19T00:00:00.000000000Z",
              "ended_at": "2021-11-19T00:00:00.000000000Z",
              "ended_by": null,
              "duration_seconds": 120,
              "settings": {
                "multi_choice": {
                  "is_enabled": true
                },
                "subscriber_only": {
                  "is_enabled": false
                },
                "subscriber_multiplier": {
                  "is_enabled": false
                },
                "bits_votes": {
                  "is_enabled": false,
                  "cost": 0
                },
                "channel_points_votes": {
                  "is_enabled": false,
                  "cost": 0
                }
              },
              "status": "COMPLETED",
              "choices": [
                {
                  "choice_id": "00257d00-2654-4f64-9f96-c1b4c44c2a53",
                  "title": "sample text",
                  "votes": {
                    "total": 0,
                    "bits": 0,
                    "channel_points": 0,
                    "base": 0
                  },
                  "tokens": {
                    "bits": 0,
                    "channel_points": 0
                  },
                  "total_voters": 0
                },
                {
                  "choice_id": "f6044b0a-fe80-46c6-8879-6f05fe5bdfcb",
                  "title": "zneixApu",
                  "votes": {
                    "total": 1,
                    "bits": 0,
                    "channel_points": 0,
                    "base": 1
                  },
                  "tokens": {
                    "bits": 0,
                    "channel_points": 0
                  },
                  "total_voters": 1
                },
                {
                  "choice_id": "c4e51b2c-7c7b-4e85-833d-2fbb7ef19089",
                  "title": "zneixFlower",
                  "votes": {
                    "total": 0,
                    "bits": 0,
                    "channel_points": 0,
                    "base": 0
                  },
                  "tokens": {
                    "bits": 0,
                    "channel_points": 0
                  },
                  "total_voters": 0
                },
                {
                  "choice_id": "b6f7c865-94d7-4ff2-8338-526146bd62e9",
                  "title": "pajaDank",
                  "votes": {
                    "total": 0,
                    "bits": 0,
                    "channel_points": 0,
                    "base": 0
                  },
                  "tokens": {
                    "bits": 0,
                    "channel_points": 0
                  },
                  "total_voters": 0
                },
                {
                  "choice_id": "5bf80362-4c0f-4052-ad6c-6d4b61ed2cd5",
                  "title": "pajaM",
                  "votes": {
                    "total": 0,
                    "bits": 0,
                    "channel_points": 0,
                    "base": 0
                  },
                  "tokens": {
                    "bits": 0,
                    "channel_points": 0
                  },
                  "total_voters": 0
                }
              ],
              "votes": {
                "total": 1,
                "bits": 0,
                "channel_points": 0,
                "base": 1
              },
              "tokens": {
                "bits": 0,
                "channel_points": 0
              },
              "total_voters": 1,
              "remaining_duration_milliseconds": 0,
              "top_contributor": null,
              "top_bits_contributor": null,
              "top_channel_points_contributor": null
            }
          }
        }
        """;

    [Topic("polls.1234567", MessageTopic.Polls, typeof(Polls))]
    public const string PollArchivedJson = """
        {
          "type": "POLL_ARCHIVE",
          "data": {
            "poll": {
              "poll_id": "3315d0af-5ecd-42b4-9bc1-ab0e1bc5899d",
              "owned_by": "11148817",
              "created_by": "117691339",
              "title": "FeelsDankMan",
              "started_at": "2021-11-19T00:00:00.000000000Z",
              "ended_at": "2021-11-19T00:00:00.000000000Z",
              "ended_by": null,
              "duration_seconds": 120,
              "settings": {
                "multi_choice": {
                  "is_enabled": true
                },
                "subscriber_only": {
                  "is_enabled": false
                },
                "subscriber_multiplier": {
                  "is_enabled": false
                },
                "bits_votes": {
                  "is_enabled": false,
                  "cost": 0
                },
                "channel_points_votes": {
                  "is_enabled": false,
                  "cost": 0
                }
              },
              "status": "ARCHIVED",
              "choices": [
                {
                  "choice_id": "00257d00-2654-4f64-9f96-c1b4c44c2a53",
                  "title": "sample text",
                  "votes": {
                    "total": 0,
                    "bits": 0,
                    "channel_points": 0,
                    "base": 0
                  },
                  "tokens": {
                    "bits": 0,
                    "channel_points": 0
                  },
                  "total_voters": 0
                },
                {
                  "choice_id": "f6044b0a-fe80-46c6-8879-6f05fe5bdfcb",
                  "title": "zneixApu",
                  "votes": {
                    "total": 1,
                    "bits": 0,
                    "channel_points": 0,
                    "base": 1
                  },
                  "tokens": {
                    "bits": 0,
                    "channel_points": 0
                  },
                  "total_voters": 1
                },
                {
                  "choice_id": "c4e51b2c-7c7b-4e85-833d-2fbb7ef19089",
                  "title": "zneixFlower",
                  "votes": {
                    "total": 0,
                    "bits": 0,
                    "channel_points": 0,
                    "base": 0
                  },
                  "tokens": {
                    "bits": 0,
                    "channel_points": 0
                  },
                  "total_voters": 0
                },
                {
                  "choice_id": "b6f7c865-94d7-4ff2-8338-526146bd62e9",
                  "title": "pajaDank",
                  "votes": {
                    "total": 0,
                    "bits": 0,
                    "channel_points": 0,
                    "base": 0
                  },
                  "tokens": {
                    "bits": 0,
                    "channel_points": 0
                  },
                  "total_voters": 0
                },
                {
                  "choice_id": "5bf80362-4c0f-4052-ad6c-6d4b61ed2cd5",
                  "title": "pajaM",
                  "votes": {
                    "total": 0,
                    "bits": 0,
                    "channel_points": 0,
                    "base": 0
                  },
                  "tokens": {
                    "bits": 0,
                    "channel_points": 0
                  },
                  "total_voters": 0
                }
              ],
              "votes": {
                "total": 1,
                "bits": 0,
                "channel_points": 0,
                "base": 1
              },
              "tokens": {
                "bits": 0,
                "channel_points": 0
              },
              "total_voters": 1,
              "remaining_duration_milliseconds": 0,
              "top_contributor": null,
              "top_bits_contributor": null,
              "top_channel_points_contributor": null
            }
          }
        }
        """;

    [Topic("low-trust-users.1234567.1234567", MessageTopic.LowTrustUsers, typeof(LowTrustUser))]
    public const string LowTrustTreatmentUpdateJson = """
        {
          "type": "low_trust_user_treatment_update",
          "data": {
            "low_trust_id": "117691339.612102198",
            "channel_id": "117691339",
            "updated_by": {
              "id": "117691339",
              "login": "mm2pl",
              "display_name": "Mm2PL"
            },
            "updated_at": "2022-01-01T00:00:00Z",
            "target_user_id": "612102198",
            "target_user": "117691339",
            "treatment": "NO_TREATMENT",
            "ban_evasion_evaluation": "UNLIKELY_EVADER",
            "evaluated_at": "2022-01-01T00:00:00Z"
          }
        }
        """;

    [Topic("low-trust-users.1234567.1234567", MessageTopic.LowTrustUsers, typeof(LowTrustUser))]
    public const string LowTrustNewMessageJson = """
        {
          "type": "low_trust_user_new_message",
          "data": {
            "low_trust_user": {
              "id": "612102198",
              "low_trust_id": "MTE3NjkxMzM5LjYxMjEwMjE5OA==",
              "channel_id": "117691339",
              "sender": {
                "user_id": "612102198",
                "login": "117691339",
                "display_name": "117691339"
              },
              "evaluated_at": "2022-01-01T00:00:00Z",
              "updated_at": "2022-01-01T00:00:00Z",
              "ban_evasion_evaluation": "UNLIKELY_EVADER",
              "treatment": "RESTRICTED",
              "updated_by": {
                "id": "117691339",
                "login": "mm2pl",
                "display_name": "Mm2PL"
              }
            },
            "message_content": {
              "text": "asd",
              "fragments": [
                {
                  "text": "asd"
                }
              ]
            },
            "message_id": "7df72edb-b757-4d0b-96f2-1fa44c988ca0",
            "sent_at": "2022-01-01T00:00:00Z"
          }
        }
        """;

    [Topic("broadcast-settings-update.1234567", MessageTopic.BroadcastSettingsUpdate, typeof(BroadcastSettingsUpdate))]
    public const string BroadcasterSettingsUpdateJson = """
        {
          "type": "broadcast_settings_update",

          "channel": "mm2pl",
          "channel_id": "117691339",

          "old_status": "FeelsDankMan",
          "status": "FeelsDankMan ...",

          "old_game": "Science \\u0026 Technology",
          "game": "Science \\u0026 Technology",

          "old_game_id": 509670,
          "game_id": 509670
        }
        """;

    [Topic("channel-bits-badge-unlocks.1234567", MessageTopic.BitsBadgeUnlock, typeof(BitsBadgeUnlock))]
    public const string BitsBadgeEventsJson = """
        {
          "user_id": "232889822",
          "user_name": "willowolf",
          "channel_id": "401394874",
          "channel_name": "fun_test12345",
          "badge_tier": 1000,
          "chat_message": "this should be received by the public pubsub listener",
          "time": "2020-12-06T00:01:43.71253159Z"
        }
        """;

    [Topic("channel-bits-events-v2.1234567", MessageTopic.BitsEventsV2, typeof(BitsBadgeUnlock))]
    public const string BitsEvents = """
        {
          "data": {
            "badge_entitlement": {
              "new_version": 25000,
              "previous_version": 10000
            },
            "bits_used": 10000,
            "channel_id": "46024993",
            "channel_name": "bontakun",
            "chat_message": "cheer10000 New badge hype!",
            "context": "cheer",
            "time": "2017-02-09T13:23:58.168Z",
            "total_bits_used": 25000,
            "user_id": "95546976",
            "user_name": "jwp"
          },
          "is_anonymous": true,
          "message_id": "8145728a4-35f0-4cf7-9dc0-f2ef24de1eb6",
          "message_type": "bits_event",
          "version": "1.0"
        }
        """;

    [Topic("chatrooms-user-v1.1234567", MessageTopic.ChatroomsUser, typeof(ChatroomsUser))]
    public const string SelfTimedOutJson = """
        {
          "type": "user_moderation_action",
          "data": {
            "action": "timeout",
            "channel_id": "72256775",
            "expires_at": "2022-05-08T12:54:07.263176344Z",
            "expires_in_ms": 974,
            "reason": "Banned phrase 3231 (vanish)",
            "target_id": "99631238"
          }
        }
        
        """;

    [Topic("chatrooms-user-v1.1234567", MessageTopic.ChatroomsUser, typeof(ChatroomsUser))]
    public const string SelfBannedJson = """
        {
          "type": "user_moderation_action",
          "data": {
            "action": "ban",
            "channel_id": "648946956",
            "reason": "foo bar baz",
            "target_id": "99631238"
          }
        }
        """;

    [Topic("chatrooms-user-v1.1234567", MessageTopic.ChatroomsUser, typeof(ChatroomsUser))]
    public const string SelfUntimedOutJson = """
        {
          "type": "user_moderation_action",
          "data": {
            "action": "untimeout",
            "channel_id": "648946956",
            "target_id": "99631238"
          }
        }
        """;

    [Topic("chatrooms-user-v1.1234567", MessageTopic.ChatroomsUser, typeof(ChatroomsUser))]
    public const string SelfUnbannedJson = """
        {
          "type": "user_moderation_action",
          "data": {
            "action": "unban",
            "channel_id": "648946956",
            "target_id": "99631238"
          }
        }
        
        """;

    [Topic("chatrooms-user-v1.1234567", MessageTopic.ChatroomsUser, typeof(ChatroomsUser))]
    public const string AliasRestrictionUpdateJson = """
        {
          "type": "channel_banned_alias_restriction_update",
          "data": {
            "user_is_restricted": false,
            "ChannelID": "648946956"
          }
        }
        """;

    [Topic("automod-queue.27620241.27620241", MessageTopic.AutomodQueue, typeof(AutoModQueue))]
    public const string AutomodQueueJson = """
        {
            "type":"automod_caught_message",
            "data":{
                "content_classification":{
                    "category":"aggression",
                    "level":4
                },
                "message":{
                    "content":{
                        "text":"you suck balls",
                        "fragments":[
                            {
                                "text":"you suck balls",
                                "automod":{
                                    "topics":{
                                        "bullying":3,
                                        "dating_and_sexting":7,
                                        "vulgar":5
                                    }
                                }
                            }
                        ]
                    },
                    "id":"23b15313-ff6c-4e1c-8d0d-ea9c382a3806",
                    "sender":{
                        "user_id":"268131879",
                        "login":"prettyb0i_swe",
                        "display_name":"prettyb0i_swe"
                    },
                    "sent_at":"2021-05-29T13:12:41.237693525Z"
                },
                "reason_code":"",
                "resolver_id":"",
                "resolver_login":"",
                "status":"PENDING"
            }
        }
        """;

    [Topic("automod-queue.27620241.27620241", MessageTopic.AutomodQueue, typeof(AutoModQueue))]
    public const string AutomodQueueJson2 = """
        {
            "type":"automod_caught_message",
            "data":{
                "content_classification":{
                    "category":"homophobia",
                    "level":1
                },
                "message":{
                    "content":{
                        "text":"Automod had an issues with the word deps?",
                        "fragments":[
                            {
                                "text":"Automod had an issues with the word "
                            },
                            {
                                "text":"deps?",
                                "automod":{
                                    "topics":{
                                        "identity":7
                                    }
                                }
                            }
                        ]
                    },
                    "id":"933829c6-9db6-4b16-8f9d-4569cd4dd8d7",
                    "sender":{
                        "user_id":"1234",
                        "login":"justinfan123",
                        "display_name":"justinfan123",
                        "chat_color":"#B382E8",
                        "badges":[
                            {
                                "id":"partner",
                                "version":"1"
                            }
                        ]
                    },
                    "sent_at":"2021-10-18T19:12:01.860963699Z",
                    "non_broadcaster_language":"fr"
                },
                "reason_code":"",
                "resolver_id":"",
                "resolver_login":"",
                "status":"PENDING"
            }
        }
        """;
}